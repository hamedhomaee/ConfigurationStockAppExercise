using ConfigurationStocksApp.FinnhubService;
using ConfigurationStocksApp.Options;
using ConfigurationStocksApp.ServiceContracts;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

builder.Services.AddScoped<IFinnhubService>(provider =>
{
    var myOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<TradingOptions>>().Value;

    return new FinnhubService(myOptions.FinnhubAPIKey!);
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();