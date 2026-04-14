using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Mobile.Core.Services;

public class AuthService : IAuthService
{
    private readonly IApiService _apiService;

    public AuthService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<bool> LoginAsync(LoginResponseDto request)
    {
        try
        {
            // Login isteği gönderiliyor
            return await _apiService.PostAsync<LoginResponseDto, bool>("auth/login", request);
        }
        catch (Exception)
        {
            return false;
        }
    }

    //1: RegisterAsync Metodu
    public async Task<bool> RegisterAsync(object registerData)
    {
        try
        {
            return await _apiService.PostAsync<object, bool>("auth/register", registerData);
        }
        catch (Exception ex)
        {
            // 1. BURAYA BREAKPOINT KOY: ex değişkeninin üzerine mouse ile gelip incele
            // 2. Output (Çıktı) penceresine detaylı hatayı yazdırır
            System.Diagnostics.Debug.WriteLine($"********** KAYIT HATASI: {ex.Message}");

            if (ex.InnerException != null)
                System.Diagnostics.Debug.WriteLine($"********** İÇ HATA: {ex.InnerException.Message}");

            // Hatayı yukarı fırlatırsan ViewModel içindeki catch bloğunda uyarı mesajı çıkarabilirsin
            throw;
        }
        //try
        //{
        //    // Kayıt isteği gönderiliyor
        //    return await _apiService.PostAsync<object, bool>("auth/register", registerData);
        //}
        //catch (Exception ex)
        //{
        //    return false;
        //}
    }

    // 2: LogoutAsync Metodu
    public async Task LogoutAsync()
    {
        try
        {
            // Genelde çıkış işlemi için backend'e bir bildirim gönderilir veya sadece yerel veriler temizlenir
            await _apiService.PostAsync<object, bool>("auth/logout", new { });
        }
        catch
        {
            // Çıkış hatası genelde kullanıcıya yansıtılmaz
        }
    }
}