using AutoMapper;
using Backend.Application.DTOs.Users;
using Backend.Application.Services.Jwt;
using Backend.Domain.Entities;
using Backend.Infrastructure.Persistence.Repositories;
using System.Security.Authentication;

namespace Backend.Application.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public UserService(UserRepository userRepository, IMapper mapper, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<UserAuthResponseDTO> RegisterAsync(CreateUserDTO createUserDTO)
    {
        var user = _mapper.Map<User>(createUserDTO);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDTO.Password);

        var createUser = await _userRepository.CreateAsync(user);
        var token = _jwtService.GenerateToken(createUser);
        var readUserdto = _mapper.Map<ReadUserDTO>(createUser);

        return new UserAuthResponseDTO { User = readUserdto, Token = token };
    }

    public async Task<UserAuthResponseDTO> LoginAsync(LoginUserDTO loginUserDTO)
    {
        var user = await _userRepository.GetByEmailAsync(loginUserDTO.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.PasswordHash))
        {
            throw new InvalidCredentialException("Email ou senha fornecidos inválidos!");
        }

        var token = _jwtService.GenerateToken(user);
        var readUserdto = _mapper.Map<ReadUserDTO>(user);

        return new UserAuthResponseDTO { User = readUserdto, Token = token };
    }
    public async Task<ReadUserDTO?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return _mapper.Map<ReadUserDTO>(user);
    }
    public async Task<ReadUserDTO?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;

        return _mapper.Map<ReadUserDTO>(user);
    }


    public async Task<ReadUserDTO?> UpdateAsync(Guid id, UpdateUserDTO updateUserDTO)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        if (!string.IsNullOrEmpty(updateUserDTO.DisplayName))
            user.DisplayName = updateUserDTO.DisplayName;

        if (!string.IsNullOrEmpty(updateUserDTO.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserDTO.Password);

        var updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<ReadUserDTO>(updatedUser);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _userRepository.DeleteAsync(id);
    }

}
