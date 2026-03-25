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

            var response = await _apiService.Login(new LoginDto
            {
                Email = Email,
                Password = Password
            });

            if (!response.Success)
            {
                await Shell.Current.DisplayAlert("Hata", response.Message, "OK");
                return;
            }

            var token = response.Data?.AccessToken;

            if (string.IsNullOrWhiteSpace(token))
            {
                await Shell.Current.DisplayAlert("Hata", "Token alınamadı", "OK");
                return;
            }

            await _tokenStorage.SaveTokenAsync(token);

            Email = "";
            Password = "";

            await Shell.Current.GoToAsync("//listings");
        }
        catch (Refit.ApiException ex)
        {
            await Shell.Current.DisplayAlert("API Hatası", ex.Content ?? "Sunucu hatası", "OK");
        }
        catch (HttpRequestException)
        {
            await Shell.Current.DisplayAlert("Bağlantı", "İnternet yok", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
