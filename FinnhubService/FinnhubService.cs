using ConfigurationStocksApp.ServiceContracts;
using System.Net.Http;
using System.Text.Json;

namespace ConfigurationStocksApp.FinnhubService;

public class FinnhubService : IFinnhubService
{
    private readonly string? _token;

    public FinnhubService(string token)
    {
        _token = token;
    }

    public async Task<Dictionary<string, object>?> GetCompanyProfileAsync(string stockSymbol)
    {
        return await GetDictionaryDataAsync("https://finnhub.io/api/v1/stock/profile2", stockSymbol, _token!);
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuoteAsync(string stockSymbol)
    {
        return await GetDictionaryDataAsync("https://finnhub.io/api/v1/quote", stockSymbol, _token!);
    }

    private static async Task<Dictionary<string, object>?> GetDictionaryDataAsync(string url, string stockSymbol, string token)
    {
        using (HttpClient httpClient = new())
        {
            var response = await httpClient.GetAsync($"{url}?symbol={stockSymbol}&token={token}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString, options);
        }
    }
}