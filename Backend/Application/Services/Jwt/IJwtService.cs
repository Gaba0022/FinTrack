using Backend.Domain.Entities;

namespace Backend.Application.Services.Jwt;

public interface IJwtService
{
    string GenerateToken(User user);
}
