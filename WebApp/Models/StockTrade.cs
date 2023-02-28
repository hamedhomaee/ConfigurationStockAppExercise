namespace ConfigurationStocksApp.WebApp.Models;

public class StockTrade
{
    public string? StockSymbol { set; get; }

    public string? StockName { set; get; }

    public double Price { set; get; }

    public int Quantity { set; get; }
}