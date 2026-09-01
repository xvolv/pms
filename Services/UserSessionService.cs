using Microsoft.AspNetCore.Components.Authorization;

namespace ERP.V7.WebPMS.Services;

public class UserSessionService
{
    private readonly AuthenticationStateProvider _authStateProvider;

    public UserSessionService(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    public async Task<string?> GetTinAsync() =>
        (await GetUserAsync()).FindFirst("Tin")?.Value;

    public async Task<string?> GetUsernameAsync() =>
        (await GetUserAsync()).Identity?.Name;

    public async Task<int?> GetConsigneeUnitIdAsync() =>
        ParseInt((await GetUserAsync()).FindFirst("ConsigneeUnitId")?.Value);

    public async Task<string?> GetConsigneeUnitNameAsync() =>
        (await GetUserAsync()).FindFirst("ConsigneeUnitName")?.Value;

    public async Task<int?> GetUserIdAsync() =>
        ParseInt((await GetUserAsync()).FindFirst("UserId")?.Value);

    public async Task<int?> GetRoleAsync() =>
        ParseInt((await GetUserAsync()).FindFirst("Role")?.Value);

    private async Task<System.Security.Claims.ClaimsPrincipal> GetUserAsync()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();
        return state.User;
    }

    private static int? ParseInt(string? value) =>
        int.TryParse(value, out var parsed) ? parsed : null;
}
