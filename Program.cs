using System.Security.Claims;
using ERP.V7.WebPMS.Components;
using ERP.V7.WebPMS.Services;
using ERP.V7.WebPMS.Services.Common;
using ERP.Components.Pages.SettingsAndMiscellaneous.Package.Services;
using ERP.V7.WebPMS.Services.Dashboard;
using ERP.V7.WebPMS.Services.DocumentBrowser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddDevExpressBlazor();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IDocumentBrowserService, DocumentBrowserService>();
builder.Services.AddScoped<PackageDetailService>();
builder.Services.AddScoped<PackageHeaderService>();
builder.Services.AddScoped<FolioService>();
builder.Services.AddScoped<RecentPagesService>();
builder.Services.AddScoped<UserSessionService>();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.AccessDeniedPath = "/";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapGet("/account/signin", async (HttpContext ctx, string tin, string username, int consigneeUnitId, string? consigneeUnitName, int? userId, int? role) =>
{
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, username),
        new("Tin", tin),
        new("ConsigneeUnitId", consigneeUnitId.ToString()),
    };
    if (!string.IsNullOrEmpty(consigneeUnitName))
        claims.Add(new Claim("ConsigneeUnitName", consigneeUnitName));
    if (userId.HasValue)
        claims.Add(new Claim("UserId", userId.Value.ToString()));
    if (role.HasValue)
        claims.Add(new Claim("Role", role.Value.ToString()));

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    return Results.Redirect("/dashboard");
});

app.MapGet("/account/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});

app.MapGet("/account/validate", (HttpContext ctx) =>
{
    var isAuthenticated = ctx.User.Identity?.IsAuthenticated == true;
    return Results.Ok(new { authenticated = isAuthenticated });
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
