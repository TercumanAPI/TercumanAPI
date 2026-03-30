using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    // HATA BURADAYDI: Interface'deki metodu burada 'public' ve 'async' olarak tanımlamalıyız.
    // Parametre tipi 'LoginRequestDto' olmalı!
    public async Task<bool> LoginAsync(LoginResponseDto request)
    {
        try
        {
            // ApiService üzerinden backend'deki 'auth/login' endpoint'ine POST isteği atıyoruz.
            // Backend'den 'bool' (true/false) beklediğimiz durum:
            var result = await _apiService.PostAsync<LoginResponseDto, bool>("auth/login", request);

            return result;
        }
        catch (Exception ex)
        {
            // Hata durumunda (bağlantı kopması, 401 vb.) false dönüyoruz.
            // İleride buraya hata loglama ekleyebilirsin.
            return false;
        }
    }

    // İleride Register için de buraya metot ekleyebilirsin:
    // public async Task<bool> RegisterAsync(RegisterRequestDto request) { ... }
}