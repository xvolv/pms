using Microsoft.AspNetCore.Components.Authorization;

namespace ERP.V7.WebPMS.Services;

public class UserSessionService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly IApiService _apiService;
    private PmsAccessDTO? _pmsAccess;
    private bool _pmsAccessLoaded;

    public UserSessionService(AuthenticationStateProvider authStateProvider, IApiService apiService)
    {
        _authStateProvider = authStateProvider;
        _apiService = apiService;
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

    public async Task<PmsAccessDTO?> GetPmsAccessAsync()
    {
        if (_pmsAccessLoaded)
        {
            return _pmsAccess;
        }

        var consigneeUnitId = await GetConsigneeUnitIdAsync();
        var userId = await GetUserIdAsync();

        if (consigneeUnitId.HasValue && userId.HasValue)
        {
            var result = await _apiService.GetPmsAccessAsync(consigneeUnitId.Value, userId.Value);
            if (result?.Success == true)
            {
                _pmsAccess = result.Data;
            }
        }

        _pmsAccessLoaded = true;
        return _pmsAccess;
    }

    private const string KeySeparator = "|||";

    private HashSet<string>? _grantedPermissionKeys;

    /// <summary>
    /// Checks the backend accessPermissionList for an exact (category, description) match.
    /// Both must match - the backend returns the same description under more than one
    /// category, and those are distinct permissions, not duplicates to collapse.
    /// </summary>
    // public async Task<bool> HasAccessAsync(string category, string description)
    // {
    //     var access = await GetPmsAccessAsync();
    //     _grantedPermissionKeys ??= access?.AccessPermissionList?
    //         .Where(p => !string.IsNullOrWhiteSpace(p.Category) && !string.IsNullOrWhiteSpace(p.Description))
    //         .Select(p => PermissionKey(p.Category!, p.Description!))
    //         .ToHashSet()
    //         ?? new HashSet<string>();

    //     return _grantedPermissionKeys.Contains(PermissionKey(category, description));
    // }
    public async Task<bool> HasAccessAsync(string category, string description)
    {
        // TEMPORARY TEST ONLY
        if (category == "House Keeping" && description == "Room Management")
            return false;

        if (category == "Front Desk Routines" && description == "Room Type")
            return false;

        var access = await GetPmsAccessAsync();

        _grantedPermissionKeys ??= access?.AccessPermissionList?
            .Where(p => !string.IsNullOrWhiteSpace(p.Category) &&
                        !string.IsNullOrWhiteSpace(p.Description))
            .Select(p => PermissionKey(p.Category!, p.Description!))
            .ToHashSet()
            ?? new HashSet<string>();

        return _grantedPermissionKeys.Contains(
            PermissionKey(category, description));
    }

    private static string PermissionKey(string category, string description) =>
        (category.Trim() + KeySeparator + description.Trim()).ToUpperInvariant();

    private async Task<System.Security.Claims.ClaimsPrincipal> GetUserAsync()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();
        return state.User;
    }

    private static int? ParseInt(string? value) =>
        int.TryParse(value, out var parsed) ? parsed : null;
}
