using Tercuman.Mobile.Storage;

namespace Tercuman.Mobile.Services;

public class AuthService
{
    private readonly TokenStorageService _tokenStorageService;

    public AuthService(TokenStorageService tokenStorageService)
    {
        _tokenStorageService = tokenStorageService;
    }

    public async Task<bool> IsLoggedInAsync()
    {
        var token = await _tokenStorageService.GetTokenAsync();
        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task LogoutAsync()
    {
        await _tokenStorageService.ClearTokenAsync();
    }
}
