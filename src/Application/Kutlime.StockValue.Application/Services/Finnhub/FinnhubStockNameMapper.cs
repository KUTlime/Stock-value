using Kutlime.StockValue.Application.Exceptions;
using Kutlime.StockValue.Application.Interfaces;

namespace Kutlime.StockValue.Application.Services.Finnhub;

internal class FinnhubStockNameMapper
	: IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResponse, FinnhubStockNameService.FinnhubSymbolResultContract>,
		IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResult, FinnhubStockNameService.FinnhubSymbolContract>
{
	TResult IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResponse, FinnhubStockNameService.FinnhubSymbolResultContract>.Map<TInput, TResult>(TInput inputObject) =>
		(TResult)new FinnhubStockNameService.FinnhubSymbolResultContract(
			Count: inputObject.Count,
			Results: inputObject.Results ?? throw new InvalidMapperUse("Results")
		);

	TResult IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResult, FinnhubStockNameService.FinnhubSymbolContract>.Map<TInput, TResult>(TInput inputObject) =>
		(TResult)new FinnhubStockNameService.FinnhubSymbolContract(
			Description: inputObject.Description ?? throw new InvalidMapperUse("Description"),
			DisplaySymbol: inputObject.DisplaySymbol ?? throw new InvalidMapperUse("DisplaySymbol"),
			Symbol: inputObject.Symbol ?? throw new InvalidMapperUse("Symbol"),
			Type: inputObject.Type ?? throw new InvalidMapperUse("Type"));
}