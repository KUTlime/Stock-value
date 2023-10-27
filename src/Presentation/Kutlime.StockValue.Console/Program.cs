namespace Kutlime.StockValue.Console;

internal static class Program
{
    private static async Task Main()
    {
        var cancellationTokenSource = RegisterCancellationToken();
        var serviceProvider = ServiceFactory.GetServiceCollection("Finnhub").BuildServiceProvider();
        var stockProvider = serviceProvider.GetRequiredService<IStockProvider>();
        System.Console.Write("Entry stock name: ");
        string stockName = System.Console.ReadLine() ?? "MSFT";
        var (name, stockPrice) = await TryGetStockValue(stockProvider, stockName, cancellationTokenSource.Token);
        System.Console.WriteLine($"Stock: {name.Name} price: {stockPrice.Current}");
    }

    private static async Task<Stock> TryGetStockValue(IStockProvider stockProvider, string stockName, CancellationToken cancellationToken)
    {
        try
        {
            return await stockProvider.GetStockWithActualPrice(new(stockName, stockName), cancellationToken);
        }
        catch (AggregateException e) when (e.InnerExceptions.Any(ex => ex is OperationCanceledException or TaskCanceledException))
        {
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        return new(new(string.Empty, string.Empty), new(0, 0, 0, 0, 0, 0));
    }

    private static CancellationTokenSource RegisterCancellationToken()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        System.Console.CancelKeyPress += (_, e) =>
        {
            System.Console.WriteLine("Canceling...");
            cancellationTokenSource.Cancel();
            e.Cancel = true;
        };
        return cancellationTokenSource;
    }
}
