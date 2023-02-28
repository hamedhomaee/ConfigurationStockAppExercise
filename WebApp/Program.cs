using ConfigurationStocksApp.FinnhubService;
using ConfigurationStocksApp.Options;
using ConfigurationStocksApp.ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

builder.Services.AddScoped<IFinnhubService>(provider =>
{
    return new FinnhubService(builder.Configuration["FinnhubAPIKey"]!);
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();