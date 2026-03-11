using Google.Apis.Auth.OAuth2.Requests;
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
    //deneme1 
    // REGISTER
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            await _authService.RegisterAsync(dto);

            return Ok(new
            {
                success = true,
                message = "User registered successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = ex.Message
            });
        }
    }

    // LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Invalid email or password"
                });
            }

            return Ok(new
            {
                success = true,
                accessToken = token
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = ex.Message
            });
        }
    }

    // REFRESH TOKEN
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest dto)
    {
        try
        {
            var newToken = await _authService.RefreshTokenAsync(dto.RefreshToken);

            return Ok(new
            {
                success = true,
                accessToken = newToken
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = ex.Message
            });
        }
    }

    // FORGOT PASSWORD
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            await _authService.ForgotPasswordAsync(dto.Email);

            return Ok(new
            {
                success = true,
                message = "Password reset link sent"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
}