using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Mobile.Services;
using Tercuman.Mobile.Storage;

namespace Tercuman.Mobile.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IApiService _apiService;
    private readonly TokenStorageService _tokenStorage;

    private string? email;
    private string? password;
    private bool isBusy;

    public LoginViewModel(IApiService apiService, TokenStorageService tokenStorage)
    {
        _apiService = apiService;
        _tokenStorage = tokenStorage;
    }

    public string? Email
    {
        get => email;
        set => SetProperty(ref email, value);
    }

    public string? Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }

    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }

    [RelayCommand]
    private async Task Login()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Hata", "Email ve şifre zorunludur.", "OK");
                return;
            }

            var request = new LoginDto
            {
                Email = Email,
                Password = Password
            };

            var response = await _apiService.Login(request);

            if (response == null)
            {
                await Shell.Current.DisplayAlert("Hata", "Sunucu hatası", "OK");
                return;
            }

            // 🔥 BURASI SENİN MODELİNE GÖRE
            if (!response.IsSuccessful)
            {
                await Shell.Current.DisplayAlert("Hata", response.Error ?? "Login başarısız", "OK");
                return;
            }

            var token = response.Value?.Token;

            if (string.IsNullOrEmpty(token))
            {
                await Shell.Current.DisplayAlert("Hata", "Token alınamadı", "OK");
                return;
            }

            await _tokenStorage.SaveTokenAsync(token);

            await Shell.Current.GoToAsync("//listings");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hata", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}