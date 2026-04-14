using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Mobile.Core.Abstractions;

public interface IAuthService
{
    // Giriş işlemi için (LoginRequestDto kullandığını varsayıyorum)
    Task<bool> LoginAsync(LoginResponseDto request);

    // Kayıt işlemi için (Object yerine varsa RegisterRequestDto kullanabilirsin)
    Task<bool> RegisterAsync(object registerData);

    // Oturumu kapatmak için
    Task LogoutAsync();
}