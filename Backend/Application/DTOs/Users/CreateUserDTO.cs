using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Users;

public class CreateUserDTO
{
    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [MaxLength(100)]
    public string? DisplayName { get; set; }
}
