﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Users;

public class LoginUserDTO
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
