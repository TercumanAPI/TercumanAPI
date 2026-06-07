using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;


namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        Title = "Giriş Yap";
    }

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;

        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Uyarı", "Lütfen tüm alanları doldurun.", "Tamam");
            return;
        }

        try
        {
            IsBusy = true;

            var request = new
            {
                Email = this.Email,
                Password = this.Password
            };

            // Servise istek gönderiliyor
            var success = await _authService.LoginAsync(request);

            if (success)
            {
                // İSTEDİĞİN YEŞİL EKRAN BİLDİRİMİ (CommunityToolkit.Maui Toast kullanılarak)
                // Kısa süreli, alt/orta-üst kısımda şık bir başarı mesajı fırlatır.
                var toast = Toast.Make("Giriş başarılı, profilinize yönlendiriliyorsunuz...", ToastDuration.Short, 14);
                await toast.Show();

                // PROFİL SAYFASINA YÖNLENDİRME
                // AppShell.xaml içindeki rotana göre tetiklenir.
                await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//ProfilePage");
            }
            else
            {
                await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Giriş işlemi gerçekleştirilemedi.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            // Backend'den gelen "E-posta veya şifre hatalı" gibi mesajlar direkt buraya düşer.
            await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToRegister()
    {
        // Rota çözünürlük hatasını ve donmayı önlemek için mutlak // eklendi
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//RegisterPage");
    }

    [RelayCommand]
    private async Task GoToForgotPassword()
    {
        // Alt rota olarak AppShell'de kayıtlı olduğu için direkt çağrılabilir
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("ForgotPasswordPage");
    }
}