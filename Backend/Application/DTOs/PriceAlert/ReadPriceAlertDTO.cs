using Backend.Domain.Entities;

namespace Backend.Application.DTOs.PriceAlert;

public class ReadPriceAlertDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string CoinId { get; set; } = null!;
    public decimal TargetPrice { get; set; }
    public AlertDirection Direction { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? TriggeredAt { get; set; }
    public DateTime? LastNotifiedAt { get; set; }
}
