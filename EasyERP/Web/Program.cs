using AutoMapper;
using Bibliotecas.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using System.Globalization;
using Web.Areas.Escolar.Services;
using Web.Libraries.Mapeamento;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);
var culture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Acesso/Index";
    options.AccessDeniedPath = "/Home/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        path: "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 30,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

var config = new MapperConfiguration(
    cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    },
    new Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory()
);
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Host.UseSerilog();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<IAcessoServices, AcessoServices>();
builder.Services.AddScoped<IPessoaServices, PessoaServices>();

builder.Services.AddScoped<IClientFactory, ClientFactory>();

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acesso}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
