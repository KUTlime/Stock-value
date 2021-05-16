using Kutlime.StockValue.Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Kutlime.StockValue.Application.Interfaces
{
	public interface IStockNameProvider
	{
		Task<StockName> GetStockName(string stockId, CancellationToken token);
	}
}