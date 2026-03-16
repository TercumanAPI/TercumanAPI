using Microsoft.AspNetCore.Mvc;
using Tercuman.Application.DTOs.Auth;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        await _authService.RegisterAsync(dto);

        return Ok(new
        {
            success = true,
            message = "User registered successfully"
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var tokenDto = await _authService.LoginAsync(dto);

        return Ok(new
        {
            success = true,
            data = tokenDto
        });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest dto)
    {
        var newTokenDto = await _authService.RefreshTokenAsync(dto.RefreshToken);

        return Ok(new
        {
            success = true,
            data = newTokenDto
        });
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        await _authService.ForgotPasswordAsync(dto.Email);

        return Ok(new { success = true, message = "Password reset link sent" });
    }
}
