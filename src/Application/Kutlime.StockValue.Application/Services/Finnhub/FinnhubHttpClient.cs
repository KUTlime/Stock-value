using Kutlime.StockValue.Application.Interfaces;

namespace Kutlime.StockValue.Application.Services.Finnhub;

public class FinnhubHttpClient : IHttpClient
{
    private readonly HttpClient _client = new();

    public async Task<string> GetStringAsync(string uri, CancellationToken token) => await _client.GetStringAsync(uri, token);
}
