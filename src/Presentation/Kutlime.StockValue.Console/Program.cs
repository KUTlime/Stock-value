var cancellationTokenSource = RegisterCancellationToken();
var serviceProvider = ServiceFactory.GetServiceCollection("Finnhub").BuildServiceProvider();
var stockProvider = serviceProvider.GetRequiredService<IStockProvider>();
Console.Write("Entry stock name: ");
string stockName = Console.ReadLine() ?? "MSFT";
var (name, stockPrice) = await TryGetStockValue(stockProvider, stockName, cancellationTokenSource.Token);
Console.WriteLine($"Stock: {name.Name} price: {stockPrice.Current}");

async Task<Stock> TryGetStockValue(IStockProvider stockProvider, string stockName, CancellationToken cancellationToken)
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
        Console.WriteLine(e.Message);
    }

    return new(new(string.Empty, string.Empty), new(0, 0, 0, 0, 0, 0));
}

CancellationTokenSource RegisterCancellationToken()
{
    var cancellationTokenSource = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) =>
    {
        Console.WriteLine("Canceling...");
        cancellationTokenSource.Cancel();
        e.Cancel = true;
    };
    return cancellationTokenSource;
}
