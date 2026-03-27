using Microsoft.Maui.Storage;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Constants;

namespace Tercuman.Mobile.Core.Services;

public class TokenStorage : ITokenStorage
{
    public Task SaveAccessTokenAsync(string token) => SecureStorage.SetAsync(StorageKeys.AccessToken, token);
    public Task<string?> GetAccessTokenAsync() => SecureStorage.GetAsync(StorageKeys.AccessToken);
    public Task RemoveAccessTokenAsync()
    {
        SecureStorage.Remove(StorageKeys.AccessToken);
        return Task.CompletedTask;
    }
}
