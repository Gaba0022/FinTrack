using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities;

public class PriceHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string CryptoCoinId { get; set; } = null!; // FK para Crypto.CoinId

    [ForeignKey(nameof(CryptoCoinId))]
    public Crypto Crypto { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,8)")]
    public decimal Price { get; set; }

    [Required]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

