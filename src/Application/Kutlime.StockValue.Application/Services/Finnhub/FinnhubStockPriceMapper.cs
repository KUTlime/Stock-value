using Kutlime.StockValue.Application.Exceptions;
using Kutlime.StockValue.Application.Interfaces;

namespace Kutlime.StockValue.Application.Services.Finnhub;

internal class FinnhubStockPriceMapper : IContractObjectMapper<FinnhubStockService.QuoteResponse, FinnhubStockService.StockPrice>
{
	TResult IContractObjectMapper<FinnhubStockService.QuoteResponse, FinnhubStockService.StockPrice>.Map<TInput, TResult>(TInput inputObject) =>
		(TResult)new FinnhubStockService.StockPrice(
			Current: inputObject.Current ?? throw new InvalidMapperUse("Current"),
			High: inputObject.High ?? throw new InvalidMapperUse("High"),
			Low: inputObject.Low ?? throw new InvalidMapperUse("Low"),
			Open: inputObject.Open ?? throw new InvalidMapperUse("Open	"),
			PreviousClose: inputObject.PreviousClose ?? throw new InvalidMapperUse("PreviousClose"),
			Time: inputObject.Time ?? throw new InvalidMapperUse("Time")
		);
}
