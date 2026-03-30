using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Constants;

namespace Tercuman.Mobile.Core.Services;

public class TokenStorage : ITokenStorage
{
    public async Task SaveTokenAsync(string token) =>
        await SecureStorage.Default.SetAsync(StorageKeys.AccessToken, token);

    public async Task<string> GetTokenAsync() =>
        await SecureStorage.Default.GetAsync(StorageKeys.AccessToken);

    public void RemoveToken() =>
        SecureStorage.Default.Remove(StorageKeys.AccessToken);
}
