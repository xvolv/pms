using ERP.V7.WebPMS.Components;
using ERP.V7.WebPMS.Services;
using ERP.V7.WebPMS.Services.Common;
using ERP.Components.Pages.SettingsAndMiscellaneous.Package.Services;
using ERP.V7.WebPMS.Services.Dashboard;
using ERP.V7.WebPMS.Services.DocumentBrowser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
