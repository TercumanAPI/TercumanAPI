using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Auth;

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

            // Backend'in beklediği camelCase yapısı
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