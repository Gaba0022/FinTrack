namespace Backend.Application.DTOs.Users;

public class UserAuthResponseDTO
{
    public string Token { get; set; }
    public ReadUserDTO User { get; set; }
}
