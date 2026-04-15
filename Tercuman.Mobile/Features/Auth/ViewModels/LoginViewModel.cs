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

            // Backend'in beklediği küçük harf yapısı (camelCase)
            var request = new
            {
                email = this.Email,
                password = this.Password
            };

            var success = await _authService.LoginAsync(request);

            if (success)
            {
                await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//DashboardPage");
            }
        }
        catch (Exception ex)
        {
            // AuthService'deki 'throw' sayesinde artık hatanın nedenini göreceğiz
            await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Giriş Hatası", ex.Message, "Tamam");
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