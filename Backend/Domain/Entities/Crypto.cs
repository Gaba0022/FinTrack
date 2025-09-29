using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities;

public class Crypto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Symbol { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal LastPrice { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<PriceAlert> Alerts { get; set; } = new List<PriceAlert>();
    public ICollection<PriceHistory> History { get; set; } = new List<PriceHistory>();

}
