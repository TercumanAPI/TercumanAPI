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
        System.Diagnostics.Debug.WriteLine("1- Login başladı");

        if (IsBusy)
        {
            return;
        }

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

            System.Diagnostics.Debug.WriteLine($"2- Email: {request.Email}");

            var response = await _apiService.Login(request);

            System.Diagnostics.Debug.WriteLine("3- API çağrısı bitti");

            if (response == null)
            {
                System.Diagnostics.Debug.WriteLine("4- Response null");
                await Shell.Current.DisplayAlert("Hata", "Sunucudan cevap alınamadı.", "OK");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"5- Status: {response.IsSuccessStatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorText = response.Error?.Content ?? "Login başarısız.";
                System.Diagnostics.Debug.WriteLine($"6- API Error: {errorText}");
                await Shell.Current.DisplayAlert("Hata", errorText, "OK");
                return;
            }

            if (response.Content == null)
            {
                System.Diagnostics.Debug.WriteLine("7- Content null");
                await Shell.Current.DisplayAlert("Hata", "Content boş geldi.", "OK");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"8- Token: {response.Content.Token}");

            await _tokenStorage.SaveTokenAsync(response.Content.Token);
            System.Diagnostics.Debug.WriteLine("9- Token kaydedildi");

            await Shell.Current.GoToAsync("//listings");
            System.Diagnostics.Debug.WriteLine("10- Listings'e gitti");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"HATA FULL: {ex}");
            await Shell.Current.DisplayAlert("Hata", ex.ToString(), "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
