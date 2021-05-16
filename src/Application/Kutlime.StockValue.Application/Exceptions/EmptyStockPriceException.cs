using System;

namespace Kutlime.StockValue.Application.Exceptions
{
	public class EmptyStockPriceException : Exception
	{
		public EmptyStockPriceException(string stockId) : base($"Stock with identifier: {stockId} has no price. Check the data resource.")
		{
		}
	}
}