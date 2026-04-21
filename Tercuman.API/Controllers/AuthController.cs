using Microsoft.AspNetCore.Mvc;
using Tercuman.Application.Interfaces;
using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // ==========================================
    // EXTERNAL LOGIN (GOOGLE & APPLE)
    // ==========================================
    [HttpPost("external-login")]
    public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginDto dto)
    {
        try
        {
            var token = await _authService.ExternalLoginAsync(
                dto.Email,
                dto.Name,
                dto.ExternalId,
                dto.Provider
            );
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            await _authService.RegisterAsync(dto);
            return Ok(new { message = "Kayıt başarılı" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest dto)
    {
        try
        {
            var token = await _authService.RefreshTokenAsync(dto.RefreshToken);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            await _authService.ForgotPasswordAsync(dto.Email);
            return Ok(new { message = "Şifre sıfırlama emaili gönderildi" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
