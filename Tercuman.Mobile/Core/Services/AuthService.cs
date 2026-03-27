using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Constants;

namespace Tercuman.Mobile.Core.Services;

public class AuthService(IApiService apiService, ITokenStorage tokenStorage, IUserSession userSession) : IAuthService
{
    public async Task<LoginResponseDto?> LoginAsync(LoginDto request, CancellationToken cancellationToken = default)
    {
        var response = await apiService.PostAsync<LoginDto, LoginResponseDto>("api/auth/login", request, cancellationToken);
        if (response?.Token is { Length: > 0 } token)
        {
            await tokenStorage.SaveAccessTokenAsync(token);
            userSession.UserId = response.UserId;
            userSession.Email = response.Email;
        }

        return response;
    }

    public async Task<bool> RegisterAsync(RegisterDto request, CancellationToken cancellationToken = default)
    {
        await apiService.PostAsync<RegisterDto, object>("api/auth/register", request, cancellationToken);
        return true;
    }

    public async Task LogoutAsync()
    {
        await tokenStorage.RemoveAccessTokenAsync();
        userSession.Clear();
    }

    public async Task<bool> IsAuthenticatedAsync()
        => !string.IsNullOrWhiteSpace(await tokenStorage.GetAccessTokenAsync());
}
