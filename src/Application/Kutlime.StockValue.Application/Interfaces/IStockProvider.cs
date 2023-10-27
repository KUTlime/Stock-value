namespace Kutlime.StockValue.Application.Interfaces;

public interface IStockProvider
{
    Task<Stock> GetStockWithActualPrice(StockName stockName, CancellationToken token);
}
