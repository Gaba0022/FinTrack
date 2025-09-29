using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.PriceHistory;

public class CreatePriceHistoryDTO
{
    [Required]
    public string CryptoCoinId { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }

}
