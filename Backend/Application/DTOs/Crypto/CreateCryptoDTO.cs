using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Crypto;

public class CreateCryptoDTO
{
    [Required]
    [MaxLength(20)]
    public string Symbol { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal LastPrice { get; set; }

}
