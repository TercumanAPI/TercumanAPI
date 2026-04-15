using Tercuman.Mobile.Core.Abstractions;

using Tercuman.Contracts.DTOs.Auth;

using System.Text.Json;



namespace Tercuman.Mobile.Core.Services;



public class AuthService : IAuthService
{
    private readonly IApiService _apiService;

    public AuthService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<bool> LoginAsync(object loginData) // Burayı object yaptık
    {
        try
        {
            var response = await _apiService.PostAsync<object, JsonElement>("auth/login", loginData);
            return response.TryGetProperty("success", out var success) && success.GetBoolean();
        }
        catch (Exception ex)
        {
            // Register'daki gibi hata temizleme kodunu buraya da ekleyebilirsin
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> RegisterAsync(object registerData)
    {
        // Buraya sadece bir tane RegisterAsync metodu yaz, 
        // 65. satırdaki hatayı almamak için kopyasını sil!
        try
        {
            var response = await _apiService.PostAsync<object, JsonElement>("auth/register", registerData);
            return response.TryGetProperty("success", out var success) && success.GetBoolean();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task LogoutAsync()
    {
        await _apiService.PostAsync<object, object>("auth/logout", new { });
    }
}