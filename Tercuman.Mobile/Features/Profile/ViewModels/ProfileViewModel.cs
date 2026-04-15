using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;

namespace Tercuman.Mobile.Features.Profile.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ProfileViewModel()
    {
        Title = "Profil ve Güvenlik Ayarları";

        // Başlangıçta varsayılanı ayarla
        SetDefaultProfilePicture();
    }

    [ObservableProperty] private string fullName;
    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;

    // Gender özelliği değiştiğinde 'OnGenderChanged' otomatik tetiklenir
    [ObservableProperty] private string gender = "Belirtilmemiş";

    [ObservableProperty] private string currentPassword;
    [ObservableProperty] private string newPassword;
    [ObservableProperty] private string confirmNewPassword;
    [ObservableProperty]
    private string bio;
    [ObservableProperty] private string profilePictureSource;

    /// <summary>
    /// Cinsiyet her değiştiğinde bu metod otomatik çalışır (CommunityToolkit özelliği)
    /// </summary>
    partial void OnGenderChanged(string value)
    {
        SetDefaultProfilePicture();
    }

    private void SetDefaultProfilePicture()
    {
        // Sadece varsayılan görsellerden biri varsa veya boşsa güncelleme yap
        bool isDefault = string.IsNullOrEmpty(ProfilePictureSource) ||
                         ProfilePictureSource == "avatar_male.png" ||
                         ProfilePictureSource == "avatar_female.png" ||
                         ProfilePictureSource == "profile_placeholder.png";

        if (isDefault)
        {
            if (Gender == "Erkek")
            {
                ProfilePictureSource = "avatar_male.png";
            }
            else if (Gender == "Kadın")
            {
                ProfilePictureSource = "avatar_female.png";
            }
            else
            {
                ProfilePictureSource = "profile_placeholder.png";
            }
        }
    }

    [RelayCommand]
    private async Task ChangeProfilePictureAsync()
    {
        if (IsBusy) return;
        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Profil Fotoğrafı Seç"
            });

            if (photo == null) return;

            IsBusy = true;
            // Kullanıcı kendi fotoğrafını seçtiğinde artık bu yol (Path) kalıcı olur
            ProfilePictureSource = photo.FullPath;

            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "Profil fotoğrafı güncellendi.", "Tamam");
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task UpdateProfile()
    {
        IsBusy = true;
        await Task.Delay(1000);
        IsBusy = false;
        await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Profil güncellendi.", "Tamam");
    }

    [RelayCommand]
    async Task UpdatePassword()
    {
        if (NewPassword != ConfirmNewPassword)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Şifreler uyuşmuyor!", "Tamam");
            return;
        }
        await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Şifre başarıyla değiştirildi.", "Tamam");
    }
}