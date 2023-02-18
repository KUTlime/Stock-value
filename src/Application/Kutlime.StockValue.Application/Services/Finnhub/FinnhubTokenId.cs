using Kutlime.StockValue.Application.Interfaces;

namespace Kutlime.StockValue.Application.Services.Finnhub;

public class FinnhubTokenId : IToken
{
    public string TokenId { get; } = "YourTokenGoesHere"; // TODO: Put it into user secrets
}
