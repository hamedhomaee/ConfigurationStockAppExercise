using Microsoft.AspNetCore.Mvc;

namespace ConfigurationStocksApp.WebApp.Controllers;

public class TradeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.Title = "Welcome to Stock Trade";
        return View();
    }
}