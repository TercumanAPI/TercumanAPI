using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Mobile.Core.Abstractions;

public interface IAuthService
{
    // Buradaki parametre tipi (LoginResponseDto) AuthService ile AYNI olmalı
    Task<bool> LoginAsync(LoginResponseDto request);
}