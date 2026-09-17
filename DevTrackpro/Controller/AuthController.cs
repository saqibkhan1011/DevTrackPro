using DevTrackPro.DTOs;
using DevTrackPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackPro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        if (!result.Succeeded) // IdentityResult uses .Succeeded
        {
            return BadRequest(result.Errors);
        }

        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);
        if (token == null) // LoginAsync returns string? (null on invalid credentials)
        {
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        return Ok(new { Token = token });
    }
}