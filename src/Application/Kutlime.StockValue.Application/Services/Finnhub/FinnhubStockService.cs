namespace Kutlime.StockValue.Application.Services.Finnhub;

public class FinnhubStockService : IStockProvider
{
    private readonly IHttpClient _client;

    private readonly IContractObjectMapper<QuoteResponse, StockPrice>
        _mapper = new FinnhubStockPriceMapper();

    private readonly IStockNameProvider _stockNameProvider;
    private readonly IToken _token;

    public FinnhubStockService(IHttpClient client, IStockNameProvider stockNameProvider, IToken token)
    {
        _client = client;
        _stockNameProvider = stockNameProvider;
        _token = token;
    }

    public async Task<Stock> GetStockWithActualPrice(StockName stockName, CancellationToken token)
    {
        var searchResultFromName = _stockNameProvider.GetStockName(stockName.Name, token);
        var searchResultFromAbbreviation = _stockNameProvider.GetStockName(stockName.Abbreviation, token);
        var validStockName = await Task.WhenAny(searchResultFromName, searchResultFromAbbreviation);
        string? response = await _client.GetStringAsync(
            $"https://finnhub.io/api/v1/quote?symbol={validStockName.Result.Abbreviation}&token={_token.TokenId}", token);
        var result = JsonSerializer.Deserialize<QuoteResponse>(response);
        var priceRaw = result ?? throw new EmptyStockPriceException($"{stockName.Name} with symbol: {stockName.Abbreviation}");
        var price = Contract.Check(priceRaw, _mapper, "Finnhub stock price quote contract failure.");
        return new(
            new(validStockName.Result.Name, validStockName.Result.Abbreviation),
            new(price.Current, price.High, price.Low, price.Open, price.PreviousClose, price.Time));
    }

    internal record QuoteResponse
    (
        [property: JsonPropertyName("c")] float? Current,
        [property: JsonPropertyName("h")] float? High,
        [property: JsonPropertyName("l")] float? Low,
        [property: JsonPropertyName("o")] float? Open,
        [property: JsonPropertyName("pc")] float? PreviousClose,
        [property: JsonPropertyName("t")] int? Time);

    internal record StockPrice(float Current, float High, float Low, float Open, float PreviousClose, int Time);
}
