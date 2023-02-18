namespace Kutlime.StockValue.Application.Exceptions;

public class StockNameCantBeFoundException : Exception
{
    public StockNameCantBeFoundException(string stockId)
        : base($"Stock with identifier: {stockId} can't be found.")
    {
    }
}
