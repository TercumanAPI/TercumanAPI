using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
    Task<TokenDto> LoginAsync(LoginDto dto);
    Task<TokenDto> RefreshTokenAsync(string refreshToken);
    Task ForgotPasswordAsync(string email);

    // Eksik olan ve hataya sebep olan metod burası:
    Task<TokenDto> ExternalLoginAsync(string email, string name, string? externalId, string provider);
}