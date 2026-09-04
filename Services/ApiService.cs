using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CNET_V7_Domain;
using CNET_V7_Domain.Misc;
using CNET_V7_Domain.Domain.ConsigneeSchema;

namespace ERP.V7.WebPMS.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, IConfiguration configuration, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<CNET_V7_Domain.Misc.ResponseModel<SystemInitDTO>?> InitializeSystemAsync(string tin)
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5181/";
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            var requestUrl = $"{baseUrl}api/SysInitialize?deviceName=null&tin={Uri.EscapeDataString(tin)}&platform=0&isWeb=true&isPOS=false";

            try
            {
                _logger.LogInformation("Calling SysInitialize API at: {RequestUrl}", requestUrl);
                var response = await _httpClient.GetFromJsonAsync<ResponseModel<SystemInitDTO>>(requestUrl, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "API call failed to {RequestUrl}. Falling back to mock data for demonstration purposes.", requestUrl);

                // Return a mock response so the UI can be tested offline
                var mockResponse = new ResponseModel<SystemInitDTO>
                {
                    Success = false,
                    Message = "Connection failed." + ex.Message,

                };
                return mockResponse;
            }
        }

        public async Task<CNET_V7_Domain.Misc.ResponseModel<LoginResponse>?> AuthenticateAsync(string username, string password, string tin, string branchId)
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5181/";
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            var requestUrl = $"{baseUrl}api/SysInitialize/authenticate?userName={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}&app_type=0&tin={Uri.EscapeDataString(tin)}&platform=0&consigneeUnit={Uri.EscapeDataString(branchId)}&saveActivity=true";

            try
            {
                _logger.LogInformation("Calling Authenticate API at: {RequestUrl}", requestUrl);
                var response = await _httpClient.GetFromJsonAsync<ResponseModel<LoginResponse>>(requestUrl, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Authentication API call failed. " + ex.Message);
                return new ResponseModel<LoginResponse>
                {
                    Success = false,
                    Message = "Connection failed: " + ex.Message
                };
            }
        }

        public async Task<CNET_V7_Domain.Misc.ResponseModel<PmsAccessDTO>?> GetPmsAccessAsync(int consigneeUnitId, int userId)
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5181/";
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            var requestUrl = $"{baseUrl}api/PMSLibrary/PMSInitialize?consigneeunit={consigneeUnitId}&userid={userId}";

            try
            {
                _logger.LogInformation("Calling PMSInitialize API at: {RequestUrl}", requestUrl);
                var httpResponse = await _httpClient.GetAsync(requestUrl);
                var body = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _logger.LogWarning("PMSInitialize API returned {StatusCode} for {RequestUrl}. Response body: {Body}",
                        (int)httpResponse.StatusCode, requestUrl, body);
                    return new ResponseModel<PmsAccessDTO>
                    {
                        Success = false,
                        Message = $"PMSInitialize returned {(int)httpResponse.StatusCode}: {body}"
                    };
                }

                return JsonSerializer.Deserialize<ResponseModel<PmsAccessDTO>>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "PMSInitialize API call failed to {RequestUrl}.", requestUrl);
                return new ResponseModel<PmsAccessDTO>
                {
                    Success = false,
                    Message = "Connection failed: " + ex.Message
                };
            }
        }
    }
}
