using Kutlime.StockValue.Application.Interfaces;
using Kutlime.StockValue.Application.Services.Finnhub;
using Microsoft.Extensions.DependencyInjection;

namespace Kutlime.StockValue.Infrastructure.DependencyInjection;

public class DependencyContainer : IContainer
{
	private static void RegisterFinnhubServices(IServiceCollection services)
	{
		services.AddScoped<IHttpClient, FinnhubHttpClient>();
		services.AddScoped<IStockProvider, FinnhubStockService>();
		services.AddScoped<IStockNameProvider, FinnhubStockNameService>();
		services.AddScoped<IToken, FinnhubTokenId>();
	}

	public IServiceCollection GetService(string serviceProvider)
	{
		IServiceCollection services = new ServiceCollection();
		switch (serviceProvider)
		{
			case "Finnhub":
				RegisterFinnhubServices(services);
				break;
		}

		return services;
	}
}