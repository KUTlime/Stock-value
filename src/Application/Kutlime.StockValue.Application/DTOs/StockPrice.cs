namespace Kutlime.StockValue.Application.DTOs;

public record StockPrice(
    float Current,
    float High,
    float Low,
    float Open,
    float PreviousClose,
    int Time);
