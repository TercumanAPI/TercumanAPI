using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Mobile.Core.Abstractions;

public interface IAuthService
{
    Task<bool> LoginAsync(object loginData); // LoginResponseDto yerine object yap
    Task<bool> RegisterAsync(object registerData);
    Task LogoutAsync();
}