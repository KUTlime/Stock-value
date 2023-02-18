using Kutlime.StockValue.Application.Interfaces;
using Kutlime.StockValue.Application.Services.Finnhub;
using Microsoft.Extensions.DependencyInjection;

namespace Kutlime.StockValue.Infrastructure.DependencyInjection;

public class DependencyContainer : IContainer
{
    public IServiceCollection GetService(string serviceProvider)
    {
        IServiceCollection services = new ServiceCollection();
        switch (serviceProvider)
        {
            case "Finnhub":
                RegisterFinnhubServices(services);
                break;
            default:
                break;
        }

        return services;
    }

    private static void RegisterFinnhubServices(IServiceCollection services) =>
        services.AddScoped<IHttpClient, FinnhubHttpClient>()
            .AddScoped<IStockProvider, FinnhubStockService>()
            .AddScoped<IStockNameProvider, FinnhubStockNameService>()
            .AddScoped<IToken, FinnhubTokenId>();
}
