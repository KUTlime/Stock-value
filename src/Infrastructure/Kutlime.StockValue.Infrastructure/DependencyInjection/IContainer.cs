namespace Kutlime.StockValue.Infrastructure.DependencyInjection;

public interface IContainer
{
    public IServiceCollection GetService(string serviceProvider);
}
