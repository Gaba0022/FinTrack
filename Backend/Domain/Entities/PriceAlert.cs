using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities;

public enum AlertDirection
{
    Above,
    Below
}

public class PriceAlert
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    // Relação com User
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    // Relação com Crypto
    [Required]
    [MaxLength(100)]
    public string CoinId { get; set; } = null!;

    [ForeignKey(nameof(CoinId))]
    public Crypto Crypto { get; set; } = null!;

    // Alerta
    [Required]
    [Column(TypeName = "decimal(18,8)")]
    public decimal TargetPrice { get; set; }

    [Required]
    public AlertDirection Direction { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? TriggeredAt { get; set; } = null;

    public DateTime? LastNotifiedAt { get; set; } = null;

}
