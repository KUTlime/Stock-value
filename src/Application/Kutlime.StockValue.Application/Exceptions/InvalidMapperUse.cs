namespace Kutlime.StockValue.Application.Exceptions;

public class InvalidMapperUse : Exception
{
    public InvalidMapperUse(string nullProperty)
        : base($"Invalid use of contract mapper. The property {nullProperty} can't be null. Are you missing a call for Contract.Check(...)")
    {
    }
}
