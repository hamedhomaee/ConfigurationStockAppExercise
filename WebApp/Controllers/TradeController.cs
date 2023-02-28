using ConfigurationStocksApp.Options;
using ConfigurationStocksApp.ServiceContracts;
using ConfigurationStocksApp.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationStocksApp.WebApp.Controllers;

public class TradeController : Controller
{
    private readonly TradingOptions? _options;
    private readonly IFinnhubService _finnhubService;

    public TradeController(IOptions<TradingOptions> options, IFinnhubService finnhubService)
    {
        _finnhubService = finnhubService;
        _options = options.Value;
    }

    [Route("/")]
    public async Task<IActionResult> IndexAsync()
    {
        ViewBag.Title = "Welcome to Stock Trade";

        Dictionary<string, Object>? priceQuote = await _finnhubService!.GetStockPriceQuoteAsync(_options!.DefaultStockSymbol!);

        Dictionary<string, Object>? companyProfile = await _finnhubService!.GetCompanyProfileAsync(_options!.DefaultStockSymbol!);

        StockTrade model = new()
        {
            StockSymbol = _options.DefaultStockSymbol,
            StockName = Convert.ToString(companyProfile!["name"]),
            Price = Convert.ToDouble(priceQuote!["c"]),
            Quantity = 100
        };

        return View(model);
    }
}