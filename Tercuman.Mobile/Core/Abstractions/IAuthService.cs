using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Mobile.Core.Abstractions;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto request, CancellationToken cancellationToken = default);
    Task<bool> RegisterAsync(RegisterDto request, CancellationToken cancellationToken = default);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
}
