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

    // DÜZELTME: LoginRequestDto yazan yeri LoginResponseDto olarak değiştir
    public async Task<bool> LoginAsync(LoginResponseDto request)
    {
        try
        {
            // Generic tiplerin (TRequest, TResponse) eşleştiğinden emin ol
            var result = await _apiService.PostAsync<LoginResponseDto, bool>("auth/login", request);
            return result;
        }
        catch (Exception)
        {
            return false;
        }
    }
}