using System.Text.Json;
using CNET_V7_Domain.Misc;
using CNET_V7_Domain.Misc.PmsDTO;
using ERP.V7.WebPMS.Services.Common;
namespace ERP.V7.WebPMS.Services.Dashboard
{
    public class DashboardService : IDashboardService

    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DashboardService> _logger;
        private readonly UserSessionService _userSession;
        private readonly ICacheService _cache;

        public DashboardService(HttpClient httpClient, IConfiguration configuration, ILogger<DashboardService> logger, UserSessionService userSession, ICacheService cache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _userSession = userSession;
            _cache = cache;
        }
        public async Task<ResponseModel<PMSDashBoardReport>?> GetPmsDashboardReportAsync(bool forceRefresh = false)
        {
            var consigneeUnitId = await _userSession.GetConsigneeUnitIdAsync();
            var date = DateTime.Today;

            return await _cache.GetOrCreateAsync(
                key: $"dashreport_pmsdashboard_{consigneeUnitId ?? 1}_{date:yyyyMMdd}",
                factory: async () =>
                {
                    var baseUrl = _configuration["ApiSettings:BaseUrl"]
                                  ?? "http://196.191.244.130:1116/";

                    if (!baseUrl.EndsWith("/"))
                        baseUrl += "/";

                    var requestUrl = $"{baseUrl}api/PmsReport/PMSDashBoardReport";

                    var requestBody = new
                    {
                        date = date.ToString("yyyy-MM-dd"),
                        consigneeunit = consigneeUnitId ?? 1
                    };

                    try
                    {
                        _logger.LogInformation("Calling PMS Dashboard API: GET {Url}", requestUrl);

                        using var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                        request.Content = JsonContent.Create(requestBody);

                        var response = await _httpClient.SendAsync(request);

                        response.EnsureSuccessStatusCode();

                        return await response.Content.ReadFromJsonAsync<ResponseModel<PMSDashBoardReport>>(
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "PMS Dashboard API call failed.");
                        return null;
                    }
                },
                slidingExpiration: TimeSpan.FromMinutes(1),
                absoluteExpiration: TimeSpan.FromMinutes(3),
                forceRefresh: forceRefresh
            );
        }

        public void InvalidateDashboardCache(int? consigneeUnitId = null)
        {
            var prefix = consigneeUnitId.HasValue ? $"dashreport_pmsdashboard_{consigneeUnitId.Value}_" : "dashreport_pmsdashboard_";
            _cache.RemoveByPrefix(prefix);
        }
    }
}