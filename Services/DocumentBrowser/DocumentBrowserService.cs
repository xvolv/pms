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

namespace ERP.V7.WebPMS.Services.DocumentBrowser
{
    public class DocumentBrowserService : IDocumentBrowserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DocumentBrowserService> _logger;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DocumentBrowserService(HttpClient httpClient, IConfiguration configuration, ILogger<DocumentBrowserService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
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

        public async Task<DateTime?> GetServerTimeAsync()
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
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to get server time from {Url}. Using DateTime.Now as fallback.", requestUrl);
            }
            return DateTime.Now;
        }

        public async Task<List<FieldFormatDTO>> GetFieldFormatsAsync(int referenceId)
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
        }

        public async Task<List<PreferenceDTO>> GetPreferencesAsync(int systemConstantId)
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
        }

        public async Task<List<SystemConstantDTO>> GetObjectStatesAsync(string type = "ObjectState Definition", string category = "Article")
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
        }

        public async Task<List<VwConsigneeViewDTO>> GetConsigneeHeaderFormattedViewAsync(ConsigneeFilterCriteria filter)
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
        }

        public async Task<List<VwVoucherHeaderDTO>> GetVoucherHeaderFormattedViewAsync(TransactionFilterCriteria filter)
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
                    try
                    {
                        var respModel = JsonSerializer.Deserialize<ResponseModel<List<VwVoucherHeaderDTO>>>(content, _jsonOptions);
                        if (respModel != null && respModel.Data != null)
                        {
                            return respModel.Data;
                        }
                    }
                    catch
                    {
                        // Fallback to direct list
                    }
                    var directList = JsonSerializer.Deserialize<List<VwVoucherHeaderDTO>>(content, _jsonOptions);
                    return directList ?? new List<VwVoucherHeaderDTO>();
                }
                return new List<VwVoucherHeaderDTO>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "voucherDocumentBrowserFieldFormatted API call failed for {Url}", requestUrl);
                return new List<VwVoucherHeaderDTO>();
            }
        }
    }
}
