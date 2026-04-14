using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Domain.Enums;
using Tercuman.Mobile.Base;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Tercuman.Mobile.Features.Profile.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ProfileViewModel()
    {
        Title = "Profil ve Güvenlik Ayarları";
        FullName = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Gender = "Belirtilmemiş";
    }

    [ObservableProperty] string fullName;
    [ObservableProperty] string email;
    [ObservableProperty] string phone;
    [ObservableProperty] string gender;
    [ObservableProperty] string currentPassword;
    [ObservableProperty] string newPassword;
    [ObservableProperty] string confirmNewPassword;

    [RelayCommand]
    async Task UpdateProfile()
    {
        IsBusy = true;
        await Task.Delay(1000);
        IsBusy = false;
        await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Profil güncellendi.", "Tamam");
    }

    [RelayCommand]
    async Task UpdatePassword()
    {
        if (NewPassword != ConfirmNewPassword)
        {
            await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Şifreler uyuşmuyor!", "Tamam");
            return;
        }
        await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Şifre başarıyla değiştirildi.", "Tamam");
    }
}