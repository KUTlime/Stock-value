using Kutlime.StockValue.Application.DTOs;

namespace Kutlime.StockValue.Application.Interfaces;

public interface IStockNameProvider
{
    Task<StockName> GetStockName(string stockId, CancellationToken token);
}
