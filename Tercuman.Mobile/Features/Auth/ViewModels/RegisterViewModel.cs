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
        // 1. Cihaz taraflı hızlı kontrol (Burayı koruyoruz)
        if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password))
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Uyarı", "Lütfen e-posta ve şifre alanlarını doldurun.", "Tamam");
            return;
        }

        IsBusy = true;
        try
        {
            int genderValue = this.Gender == "Erkek" ? 1 : 2;

            var registerRequest = new
            {
                fullName = this.FullName,
                email = this.Email,
                password = this.Password,
                gender = genderValue,
                phoneNumber = this.PhoneNumber
            };

            // AuthService artık içindeki 'throw' sayesinde bize detaylı hata mesajı gönderecek
            var success = await _authService.RegisterAsync(registerRequest);

            if (success)
            {
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "Hesabınız oluşturuldu!", "Tamam");
                await Microsoft.Maui.Controls.Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // success false dönerse ama hata fırlatılmazsa buraya düşer
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Kayıt işlemi şu an gerçekleştirilemiyor.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            // ÖNEMLİ: Artık buradaki ex.Message, AuthService'de yazdığımız 
            // "Bu email zaten kayıtlı" veya "Şifre kurallara uymuyor" mesajını içeriyor.
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Kayıt Sorunu", ex.Message, "Anladım");
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