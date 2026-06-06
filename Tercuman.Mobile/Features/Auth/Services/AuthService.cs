using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace Tercuman.Mobile.Core.Services;

public class AuthService : IAuthService
{
    private readonly IApiService _apiService;
    private readonly HttpClient _httpClient;

    // TEK VE ORTAK CONSTRUCTOR (Kilitlenmeyi ve Çökmeyi Önler)
    public AuthService(IApiService apiService, HttpClient httpClient)
    {
        _apiService = apiService;
        _httpClient = httpClient;
    }

    public async Task<bool> LoginAsync(object loginData)
    {
        try
        {
            var response = await _apiService.PostAsync<object, JsonElement>("auth/login", loginData);
            return response.TryGetProperty("success", out var success) && success.GetBoolean();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> RegisterAsync(RegisterDto model)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", model);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            var errorJson = await response.Content.ReadAsStringAsync();
            throw new Exception($"Sunucu Hatası ({response.StatusCode}): {errorJson}");
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Bağlantı kurulamadı! Lütfen interneti ve API adresini kontrol et. Detay: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task LogoutAsync()
    {
        try
        {
            // Logout işlemi sunucu bazlı bir hata verse bile uygulamanın çökmemesi için try-catch eklendi
            await _apiService.PostAsync<object, object>("auth/logout", new { });
        }
        catch (Exception)
        {
            // İsteğe bağlı olarak hatayı loglayabilirsin. 
            // Çıkış işleminde sunucu yanıt vermese de kullanıcının lokal çıkışını engellememek en iyisidir.
        }
    }
}