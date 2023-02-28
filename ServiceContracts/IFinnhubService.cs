namespace ConfigurationStocksApp.ServiceContracts;

public interface IFinnhubService
{
    Task<Dictionary<string, object>?> GetCompanyProfileAsync(string stockSymbol);

    Task<Dictionary<string, object>?> GetStockPriceQuoteAsync(string stockSymbol);
}