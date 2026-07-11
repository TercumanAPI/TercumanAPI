using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Mobile.Features.Auth.ViewModels;

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

            // HATA DÜZELTMESİ: Servisin beklediği DTO tipini burada eşleştiriyoruz.
            // Eğer servis LoginResponseDto bekliyorsa nesneyi o tipte oluşturuyoruz.
            var request = new LoginResponseDto
            {
                Email = Email,
                Password = Password
            };

            var success = await _authService.LoginAsync(request);

            if (success)
            {
                // DashboardPage'e yönlendirme
                await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//DashboardPage");
            }
            else
            {
                await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Sistem Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToRegister()
    {
        // Namespace çakışmasını önlemek için global:: kullanıyoruz
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("RegisterPage");
    }
    [RelayCommand]
    async Task GoToForgotPassword()
    {
        // AppShell'de kaydettiğimiz isimle çağırıyoruz
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("ForgotPasswordPage");
    }
}