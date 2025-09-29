namespace Backend.Application.DTOs.Users;

public class UpdateUserDTO
{
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? DisplayName { get; set; }
}
