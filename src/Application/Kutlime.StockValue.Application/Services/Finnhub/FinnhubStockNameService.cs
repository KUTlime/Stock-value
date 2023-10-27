namespace Kutlime.StockValue.Application.Services.Finnhub;

public class FinnhubStockNameService : IStockNameProvider
{
    private readonly IHttpClient _client;

    private readonly IContractObjectMapper<FinnhubSymbolResponse, FinnhubSymbolResultContract> _responseMapper = new FinnhubStockNameMapper();

    private readonly IContractObjectMapper<FinnhubSymbolResult, FinnhubSymbolContract> _symbolResponseMapper = new FinnhubStockNameMapper();
    private readonly IToken _token;

    public FinnhubStockNameService(IHttpClient client, IToken token)
    {
        _client = client;
        _token = token;
    }

    public async Task<StockName> GetStockName(string stockId, CancellationToken token)
    {
        string? response = await _client.GetStringAsync($"https://finnhub.io/api/v1/search?q={stockId}&token={_token.TokenId}", token);
        var result = JsonSerializer.Deserialize<FinnhubSymbolResponse>(response);
        var validatedResponse = Contract.Check(result, _responseMapper, "Finnhub stock symbol response contract failure. Maybe wrong input?");
        var topStockSymbol = validatedResponse.Results.FirstOrDefault();
        var stockSymbol = Contract.Check(
            topStockSymbol, _symbolResponseMapper, "Finnhub stock symbol result contract failure. The given stock symbol can't be found.");
        return new StockName(stockSymbol.Description, stockSymbol.Symbol);
    }

    internal record FinnhubSymbolResponse
    (
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("result")] IEnumerable<FinnhubSymbolResult>? Results);

    internal record FinnhubSymbolResult
    (
        [property: JsonPropertyName("description")]
        string? Description,
        [property: JsonPropertyName("displaySymbol")]
        string? DisplaySymbol,
        [property: JsonPropertyName("symbol")] string? Symbol,
        [property: JsonPropertyName("type")] string? Type);

    internal record FinnhubSymbolResultContract(int Count, IEnumerable<FinnhubSymbolResult> Results);

    internal record FinnhubSymbolContract(string Description, string DisplaySymbol, string Symbol, string Type);
}
