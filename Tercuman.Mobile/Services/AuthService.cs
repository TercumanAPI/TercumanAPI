using Microsoft.Maui.Storage;

namespace Tercuman.Mobile.Services;

public class AuthService
{
    public async Task<bool> IsLoggedInAsync()
    {
        var token = await SecureStorage.GetAsync("token");
        return !string.IsNullOrEmpty(token);
    }

    public async Task LogoutAsync()
    {
        SecureStorage.Remove("token");
    }
}