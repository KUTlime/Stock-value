namespace Kutlime.StockValue.Application;

internal class Contract
{
    [return: NotNull]
    internal static TTarget Check<TDto, TTarget>(TDto? dto, IContractObjectMapper<TDto, TTarget> mapper, string errorMessage)
    {
        bool validProperties = dto?.GetType().GetProperties().Any(p => p.GetValue(dto) is not null) ?? false;
        return validProperties ? mapper.Map<TDto, TTarget>(dto!) : throw new ContractException(errorMessage);
    }
}
