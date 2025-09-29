namespace Backend.Application.DTOs.Crypto;

public class ReadCryptoDTO
{
    public int Id { get; set; }
    public string Symbol { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal LastPrice { get; set; }
    public DateTime UpdatedAt { get; set; }

}
