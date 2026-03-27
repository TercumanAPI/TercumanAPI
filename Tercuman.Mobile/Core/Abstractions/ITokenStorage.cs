namespace Tercuman.Mobile.Core.Abstractions;

public interface ITokenStorage
{
    Task SaveAccessTokenAsync(string token);
    Task<string?> GetAccessTokenAsync();
    Task RemoveAccessTokenAsync();
}
