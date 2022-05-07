using Kutlime.StockValue.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Kutlime.StockValue.DependencyInjection;

public class ServiceFactory
{
	public static IServiceCollection GetServiceCollection(string name) =>
		name switch
		{
			"Finnhub" => ContainerProvider.Resolve().GetService(name),
			_ => throw new InvalidServiceProviderException(name)
		};
}