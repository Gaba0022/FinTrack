using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities;

public class User
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    [MaxLength(100)]
    public string? DisplayName { get; set; }

    [Column("created_in")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<PriceAlert> Alerts { get; set; } = new List<PriceAlert>();
}
