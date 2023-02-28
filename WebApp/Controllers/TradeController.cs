using ConfigurationStocksApp.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationStocksApp.WebApp.Controllers;

public class TradeController : Controller
{
    private readonly TradingOptions? _options;

    public TradeController(IOptions<TradingOptions> options)
    {
        _options = options.Value;
    }

    [Route("/")]
    public IActionResult Index()
    {
        
        ViewBag.Title = "Welcome to Stock Trade";
        return View();
    }
}