using System.Text.Json;
using CNET_V7_Domain.Misc;
using CNET_V7_Domain.Misc.PmsDTO;
namespace ERP.V7.WebPMS.Services.Dashboard
{
    public class DashboardService : IDashboardService

    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DashboardService> _logger;
        private readonly UserSessionService _userSession;

        public DashboardService(HttpClient httpClient, IConfiguration configuration, ILogger<DashboardService> logger, UserSessionService userSession)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _userSession = userSession;
        }
        public async Task<ResponseModel<PMSDashBoardReport>?> GetPmsDashboardReportAsync()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"]
                          ?? "http://196.191.244.130:1116/";

            if (!baseUrl.EndsWith("/"))
                baseUrl += "/";

            var requestUrl = $"{baseUrl}api/PmsReport/PMSDashBoardReport";

            var consigneeUnitId = await _userSession.GetConsigneeUnitIdAsync();

            var requestBody = new
            {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
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
        }


    }
}