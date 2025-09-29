using Backend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.PriceAlert;

public class CreatePriceAlertDTO
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CoinId { get; set; } = null!;

    [Required]
    public decimal TargetPrice { get; set; }

    [Required]
    public AlertDirection Direction { get; set; }
}
