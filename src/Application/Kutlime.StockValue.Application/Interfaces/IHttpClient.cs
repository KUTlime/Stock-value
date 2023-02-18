namespace Kutlime.StockValue.Application.Interfaces;

public interface IHttpClient
{
    public Task<string> GetStringAsync(string uri, CancellationToken token);
}
