using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CNET_V7_Domain.Misc;
using CNET_V7_Domain.Domain.SettingSchema;
using CNET_V7_Domain.Domain.ViewSchema;
using ERP.V7.WebPMS.Services.Common;

namespace ERP.V7.WebPMS.Services.DocumentBrowser
{
    public class DocumentBrowserService : IDocumentBrowserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DocumentBrowserService> _logger;
        private readonly ICacheService _cache;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DocumentBrowserService(
            HttpClient httpClient, 
            IConfiguration configuration, 
            ILogger<DocumentBrowserService> logger,
            ICacheService cache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _cache = cache;
        }

        private string GetBaseUrl()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"] ?? "http://196.191.244.130:1116/";
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }
            return baseUrl;
        }

        public Task<DateTime?> GetServerTimeAsync(bool forceRefresh = false)
        {
            return _cache.GetOrCreateAsync(
                key: "docbrowser_lookup_server_time",
                factory: async () =>
                {
                    var requestUrl = $"{GetBaseUrl()}api/CommonLibrary/server-time";
                    try
                    {
                        _logger.LogInformation("Calling server-time API: {Url}", requestUrl);
                        var response = await _httpClient.GetAsync(requestUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
                            if (doc.RootElement.TryGetProperty("data", out var dataProp))
                            {
                                if (dataProp.ValueKind == JsonValueKind.String && DateTime.TryParse(dataProp.GetString(), out var dt))
                                {
                                    return (DateTime?)dt;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to get server time from {Url}. Using DateTime.Now as fallback.", requestUrl);
                    }
                    return (DateTime?)DateTime.Now;
                },
                slidingExpiration: TimeSpan.FromMinutes(2),
                absoluteExpiration: TimeSpan.FromMinutes(5),
                forceRefresh: forceRefresh
            );
        }

        public Task<List<FieldFormatDTO>> GetFieldFormatsAsync(int referenceId, bool forceRefresh = false)
        {
            return _cache.GetOrCreateAsync(
                key: $"docbrowser_lookup_fieldformat_{referenceId}",
                factory: async () =>
                {
                    var requestUrl = $"{GetBaseUrl()}api/FieldFormat/Filter?reference={referenceId}";
                    try
                    {
                        _logger.LogInformation("Calling FieldFormat API: {Url}", requestUrl);
                        var result = await _httpClient.GetFromJsonAsync<List<FieldFormatDTO>>(requestUrl, _jsonOptions);
                        return result ?? new List<FieldFormatDTO>();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "FieldFormat API failed for reference={ReferenceId}", referenceId);
                        return new List<FieldFormatDTO>();
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(30),
                absoluteExpiration: TimeSpan.FromHours(2),
                forceRefresh: forceRefresh
            );
        }

        public Task<List<PreferenceDTO>> GetPreferencesAsync(int systemConstantId, bool forceRefresh = false)
        {
            return _cache.GetOrCreateAsync(
                key: $"docbrowser_lookup_pref_{systemConstantId}",
                factory: async () =>
                {
                    var requestUrl = $"{GetBaseUrl()}api/Preference/filter?SystemConstant={systemConstantId}";
                    try
                    {
                        _logger.LogInformation("Calling Preference API: {Url}", requestUrl);
                        var result = await _httpClient.GetFromJsonAsync<List<PreferenceDTO>>(requestUrl, _jsonOptions);
                        return result ?? new List<PreferenceDTO>();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Preference API failed for SystemConstant={SystemConstantId}", systemConstantId);
                        return new List<PreferenceDTO>();
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(30),
                absoluteExpiration: TimeSpan.FromHours(2),
                forceRefresh: forceRefresh
            );
        }

        public Task<List<SystemConstantDTO>> GetObjectStatesAsync(string type = "ObjectState Definition", string category = "Article", bool forceRefresh = false)
        {
            return _cache.GetOrCreateAsync(
                key: $"docbrowser_lookup_objstates_{type}_{category}",
                factory: async () =>
                {
                    var encodedType = Uri.EscapeDataString(type);
                    var encodedCategory = Uri.EscapeDataString(category);
                    var requestUrl = $"{GetBaseUrl()}api/SystemConstant/filter?Type={encodedType}&category={encodedCategory}";
                    try
                    {
                        _logger.LogInformation("Calling SystemConstant API: {Url}", requestUrl);
                        var result = await _httpClient.GetFromJsonAsync<List<SystemConstantDTO>>(requestUrl, _jsonOptions);
                        return result ?? new List<SystemConstantDTO>();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "SystemConstant API failed for Type={Type}, Category={Category}", type, category);
                        return new List<SystemConstantDTO>();
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(30),
                absoluteExpiration: TimeSpan.FromHours(2),
                forceRefresh: forceRefresh
            );
        }

        public Task<List<VwConsigneeViewDTO>> GetConsigneeHeaderFormattedViewAsync(ConsigneeFilterCriteria filter, bool forceRefresh = false)
        {
            var cacheKey = $"docbrowser_consignee_{filter.GslType}_{filter.FieldFormatType}_{filter.FromDate:yyyyMMdd}_{filter.ToDate:yyyyMMdd}_{filter.ConsigneeCode}_{filter.ChildPreferenceId}_{filter.ObjectStateId}";
            return _cache.GetOrCreateAsync(
                key: cacheKey,
                factory: async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(string.Empty);
                    queryString.Add("fieldFormatType", filter.FieldFormatType.ToString());
                    queryString.Add("gslType", filter.GslType.ToString());

                    if (filter.FromDate.HasValue && filter.ToDate.HasValue)
                    {
                        queryString.Add(":startDate", filter.FromDate.Value.ToString("MM-dd-yyyy"));
                        queryString.Add("startDate:", filter.ToDate.Value.ToString("MM-dd-yyyy"));
                    }
                    else if (filter.FromDate.HasValue && !filter.ToDate.HasValue)
                    {
                        queryString.Add(":startDate", filter.FromDate.Value.ToString("MM-dd-yyyy"));
                        queryString.Add("startDate:", filter.FromDate.Value.ToString("MM-dd-yyyy"));
                    }

                    if (!string.IsNullOrWhiteSpace(filter.ConsigneeCode))
                    {
                        queryString.Add("code", filter.ConsigneeCode.Trim());
                    }

                    if (filter.ChildPreferenceId.HasValue && filter.ChildPreferenceId.Value > 0)
                    {
                        queryString.Add("childpreferenceID", filter.ChildPreferenceId.Value.ToString());
                    }

                    if (filter.ObjectStateId.HasValue && filter.ObjectStateId.Value > 0)
                    {
                        queryString.Add("ObjectStateId", filter.ObjectStateId.Value.ToString());
                    }

                    var requestUrl = $"{GetBaseUrl()}api/ConsigneeView/consigneeHeaderFieldFormattedView?{queryString}";
                    try
                    {
                        _logger.LogInformation("Calling ConsigneeView API: {Url}", requestUrl);
                        var result = await _httpClient.GetFromJsonAsync<List<VwConsigneeViewDTO>>(requestUrl, _jsonOptions);
                        return result ?? new List<VwConsigneeViewDTO>();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "ConsigneeView API call failed for {Url}", requestUrl);
                        return new List<VwConsigneeViewDTO>();
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(10),
                absoluteExpiration: TimeSpan.FromMinutes(30),
                forceRefresh: forceRefresh
            );
        }

        public Task<List<VwVoucherHeaderDTO>> GetVoucherHeaderFormattedViewAsync(TransactionFilterCriteria filter, bool forceRefresh = false)
        {
            var cacheKey = $"docbrowser_voucher_{filter.DefinitionId}_{filter.FieldFormatType}_{filter.FromDate:yyyyMMdd}_{filter.ToDate:yyyyMMdd}_{filter.VoucherCode}";
            return _cache.GetOrCreateAsync(
                key: cacheKey,
                factory: async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(string.Empty);
                    queryString.Add("definitionId", filter.DefinitionId.ToString());
                    queryString.Add("fieldFormatType", filter.FieldFormatType.ToString());

                    // Date Range
                    if (filter.FromDate.HasValue && filter.ToDate.HasValue)
                    {
                        queryString.Add(":issuedDate", filter.FromDate.Value.ToString("MM-dd-yyyy"));
                        queryString.Add("issuedDate:", filter.ToDate.Value.ToString("MM-dd-yyyy"));
                    }
                    // Single day (Daily, At the day of)
                    else if (filter.FromDate.HasValue && !filter.ToDate.HasValue)
                    {
                        queryString.Add("issuedDate", filter.FromDate.Value.ToString("MM-dd-yyyy"));
                    }

                    if (!string.IsNullOrWhiteSpace(filter.VoucherCode))
                    {
                        queryString.Add("code", filter.VoucherCode.Trim());
                    }

                    var requestUrl = $"{GetBaseUrl()}api/DocumentBrowser/voucherDocumentBrowserFieldFormatted?{queryString}";
                    try
                    {
                        _logger.LogInformation("Calling voucherDocumentBrowserFieldFormatted API: {Url}", requestUrl);
                        var response = await _httpClient.GetAsync(requestUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            List<VwVoucherHeaderDTO>? voucherList = null;
                            try
                            {
                                var respModel = JsonSerializer.Deserialize<ResponseModel<List<VwVoucherHeaderDTO>>>(content, _jsonOptions);
                                if (respModel != null && respModel.Data != null)
                                {
                                    voucherList = respModel.Data;
                                }
                            }
                            catch
                            {
                                // Fallback to direct list
                            }

                            if (voucherList == null)
                            {
                                voucherList = JsonSerializer.Deserialize<List<VwVoucherHeaderDTO>>(content, _jsonOptions) ?? new List<VwVoucherHeaderDTO>();
                            }

                            return voucherList;
                        }
                        return new List<VwVoucherHeaderDTO>();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "voucherDocumentBrowserFieldFormatted API call failed for {Url}", requestUrl);
                        return new List<VwVoucherHeaderDTO>();
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(10),
                absoluteExpiration: TimeSpan.FromMinutes(30),
                forceRefresh: forceRefresh
            );
        }

        public void InvalidateConsigneeCache(int? gslType = null)
        {
            var prefix = gslType.HasValue ? $"docbrowser_consignee_{gslType.Value}_" : "docbrowser_consignee_";
            _cache.RemoveByPrefix(prefix);
        }

        public void InvalidateVoucherCache(int? definitionId = null)
        {
            var prefix = definitionId.HasValue ? $"docbrowser_voucher_{definitionId.Value}_" : "docbrowser_voucher_";
            _cache.RemoveByPrefix(prefix);
        }

        public void ClearCache()
        {
            _cache.RemoveByPrefix("docbrowser_");
        }
    }
}
