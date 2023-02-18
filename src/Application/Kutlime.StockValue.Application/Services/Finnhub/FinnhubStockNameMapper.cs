using Kutlime.StockValue.Application.Exceptions;
using Kutlime.StockValue.Application.Interfaces;

namespace Kutlime.StockValue.Application.Services.Finnhub;

internal class FinnhubStockNameMapper
    : IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResponse, FinnhubStockNameService.FinnhubSymbolResultContract>,
        IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResult, FinnhubStockNameService.FinnhubSymbolContract>
{
    TResult IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResponse, FinnhubStockNameService.FinnhubSymbolResultContract>.
        Map<TInput, TResult>(TInput inputObject) =>
        (TResult)new FinnhubStockNameService.FinnhubSymbolResultContract(
            inputObject.Count,
            inputObject.Results ?? throw new InvalidMapperUse("Results"));

    TResult IContractObjectMapper<FinnhubStockNameService.FinnhubSymbolResult, FinnhubStockNameService.FinnhubSymbolContract>.
        Map<TInput, TResult>(TInput inputObject) =>
        (TResult)new FinnhubStockNameService.FinnhubSymbolContract(
            inputObject.Description ?? throw new InvalidMapperUse("Description"),
            inputObject.DisplaySymbol ?? throw new InvalidMapperUse("DisplaySymbol"),
            inputObject.Symbol ?? throw new InvalidMapperUse("Symbol"),
            inputObject.Type ?? throw new InvalidMapperUse("Type"));
}
