using Backend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.PriceAlert;

public class UpdatePriceAlertDTO
{
    [Required]
    public decimal TargetPrice { get; set; }

    [Required]
    public AlertDirection Direction { get; set; }

    [Required]
    public bool IsActive { get; set; }
}
