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
    public async Task<IActionResult> Register(RegisterDto dto)
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

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized(new
                {
                    success = false,
                    message = "Invalid email or password"
                });

            return Ok(new
            {
                success = true,
                token
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