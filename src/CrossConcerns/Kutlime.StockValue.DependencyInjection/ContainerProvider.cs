#pragma warning disable IDE0005
using Kutlime.StockValue.Infrastructure.DependencyInjection;

#pragma warning restore IDE0005

namespace Kutlime.StockValue.DependencyInjection;

internal static class ContainerProvider
{
    internal static IContainer Resolve() => new DependencyContainer(); // TODO: Maybe some logic based on settings.
}
