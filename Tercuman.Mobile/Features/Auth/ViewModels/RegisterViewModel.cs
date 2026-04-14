using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    public RegisterViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty] string fullName;
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string gender;
    [ObservableProperty] string phoneNumber;

    [RelayCommand]
    async Task Register()
    {
        if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password))
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Uyarı", "Lütfen tüm alanları doldurun.", "Tamam");
            return;
        }

        IsBusy = true;
        try
        {
            // Swagger'a göre Erkek = 1, Kadın = 2
            int genderValue = this.Gender == "Erkek" ? 1 : 2;

            // KRİTİK DÜZELTME: 
            // Swagger'daki küçük harf (camelCase) yapısını birebir taklit ediyoruz.
            // Sol taraftaki isimleri Swagger'daki JSON anahtarlarıyla aynı yaptık.
            var registerRequest = new
            {
                fullName = this.FullName,
                email = this.Email,
                password = this.Password,
                gender = genderValue,
                phoneNumber = this.PhoneNumber
            };

            var success = await _authService.RegisterAsync(registerRequest);

            if (success)
            {
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "Hesabınız oluşturuldu!", "Tamam");
                await Microsoft.Maui.Controls.Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // API 200 dönmezse buraya düşer
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Kayıt başarısız. Bilgileri kontrol edin.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Sorgu Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToLogin()
    {
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
    }
}