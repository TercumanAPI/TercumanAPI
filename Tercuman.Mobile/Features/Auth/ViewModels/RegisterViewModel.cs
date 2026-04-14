using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;

namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    [ObservableProperty] string fullName;
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string gender;
    [ObservableProperty] string phoneNumber;

    [RelayCommand]
    async Task Register()
    {
        if (string.IsNullOrWhiteSpace(Email)) return;
        await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Kayıt işlemi başlatıldı.", "Tamam");
    }

    [RelayCommand]
    async Task GoToLogin()
    {
        // Bir önceki sayfa olan Login ekranına geri döner
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
    }
}