namespace Kutlime.StockValue.Application.Services.Finnhub;

internal class FinnhubStockPriceMapper : IContractObjectMapper<FinnhubStockService.QuoteResponse, FinnhubStockService.StockPrice>
{
    TResult IContractObjectMapper<FinnhubStockService.QuoteResponse, FinnhubStockService.StockPrice>.Map<TInput, TResult>(TInput inputObject) =>
        (TResult)new FinnhubStockService.StockPrice(
            inputObject.Current ?? throw new InvalidMapperUse("Current"),
            inputObject.High ?? throw new InvalidMapperUse("High"),
            inputObject.Low ?? throw new InvalidMapperUse("Low"),
            inputObject.Open ?? throw new InvalidMapperUse("Open	"),
            inputObject.PreviousClose ?? throw new InvalidMapperUse("PreviousClose"),
            inputObject.Time ?? throw new InvalidMapperUse("Time"));
}
