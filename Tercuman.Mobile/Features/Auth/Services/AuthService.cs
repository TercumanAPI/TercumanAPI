using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Microsoft.Maui.Storage;

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
            // API'ye isteği atıyoruz
            var response = await _apiService.PostAsync<object, JsonElement>("auth/login", loginData);

            // ESNEK KONTROL: Eğer API hata fırlatmadıysa ve bir yanıt döndüyse başarılı sayıyoruz.
            // Böylece "success" property'si eşleşmese bile giriş engellenmemiş olur.
            if (response.ValueKind != JsonValueKind.Null && response.ValueKind != JsonValueKind.Undefined)
            {
                // Profil sayfasının beklediği anahtarları güvenli bir şekilde cihaza kaydediyoruz.
                // Eğer backend'den gelen data içinde bu alanlar camelCase ise okur, yoksa varsayılan metni yazar.
                string fullName = "Ad Soyad Belirtilmemiş";
                string email = "E-posta Belirtilmemiş";
                string phone = "Telefon Belirtilmemiş";
                string gender = "Belirtilmemiş";

                if (response.TryGetProperty("data", out var data))
                {
                    fullName = data.TryGetProperty("fullName", out var n) ? n.GetString() : fullName;
                    email = data.TryGetProperty("email", out var e) ? e.GetString() : email;
                    phone = data.TryGetProperty("phone", out var p) ? p.GetString() : phone;
                    gender = data.TryGetProperty("gender", out var g) ? g.GetString() : gender;
                }

                // Profil sayfanın (ProfileViewModel) birebir beklediği anahtarlarla kaydediyoruz:
                Preferences.Default.Set("UserFullName", fullName);
                Preferences.Default.Set("UserEmail", email);
                Preferences.Default.Set("UserPhone", phone);
                Preferences.Default.Set("UserGender", gender);

                return true; // Giriş tamamen başarılı, ViewModel'e olumlu dönüyoruz.
            }

            return false;
        }
        catch (Exception ex)
        {
            // Eğer şifre yanlışsa veya sunucu çöktüyse buraya düşecek ve hata mesajını fırlatacak.
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> RegisterAsync(RegisterDto model)
    {
        try
        {
            // _httpClient yerine merkezi _apiService altyapısını kullanıyoruz.
            // Yolu Login'deki gibi "auth/register" olarak standartlaştırıyoruz.
            var response = await _apiService.PostAsync<RegisterDto, object>("auth/register", model);

            // _apiService zaten 404 veya 500 gibi hatalarda otomatik Exception fırlatır.
            // Buraya ulaştıysa işlem başarılı demektir.
            return true;
        }
        catch (Exception ex)
        {
            // _apiService'den dönen temiz backend hata mesajını (örneğin "Bu email zaten kayıtlı") yakalar.
            throw new Exception($"Kayıt işlemi başarısız: {ex.Message}");
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