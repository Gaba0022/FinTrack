using Backend.Application.DTOs.Users;
using Backend.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
    {
        try
        {
            var result = await _userService.RegisterAsync(dto);
            return Created("", result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
    {
        try
        {
            var result = await _userService.LoginAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { erro = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<ReadUserDTO?>> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [Authorize]
    [HttpGet("by-email/{email}")]
    public async Task<ActionResult<ReadUserDTO?>> GetByEmail(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReadUserDTO?>> UpdateUser(Guid id, [FromBody] UpdateUserDTO dto)
    {
        try
        {
            var updatedUser = await _userService.UpdateAsync(id, dto);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deleted = await _userService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
