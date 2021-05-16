using Kutlime.StockValue.Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Kutlime.StockValue.Application.Interfaces
{
	public interface IStockProvider
	{
		Task<Stock> GetStockWithActualPrice(StockName stockName, CancellationToken token);
	}
}