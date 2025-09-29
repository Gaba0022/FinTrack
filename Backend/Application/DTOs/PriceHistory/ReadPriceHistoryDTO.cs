namespace Backend.Application.DTOs.PriceHistory;

public class ReadPriceHistoryDTO
{
    public long Id { get; set; }
    public string CryptoCoinId { get; set; } = null!;
    public string CryptoSymbol { get; set; } = null!;
    public string CryptoName { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime Timestamp { get; set; }

}
