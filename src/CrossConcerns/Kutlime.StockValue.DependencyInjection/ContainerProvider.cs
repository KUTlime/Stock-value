using Kutlime.StockValue.Infrastructure.DependencyInjection;

namespace Kutlime.StockValue.DependencyInjection
{
	internal static class ContainerProvider
	{
		internal static IContainer Resolve() => new DependencyContainer(); // TODO: Maybe some logic based on settings.
	}
}
