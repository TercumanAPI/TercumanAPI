using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;

namespace Tercuman.Mobile.Features.Profile.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ProfileViewModel()
    {
        Title = "Profil ve Güvenlik Ayarları";

        // SAYFA AÇILDIĞINDA VERİLERİ OTOMATİK YÜKLE
        LoadUserData();

        // Cinsiyete göre varsayılan resmi ayarla
        SetDefaultProfilePicture();
    }

    [ObservableProperty] private string fullName;
    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;
    [ObservableProperty] private string gender = "Belirtilmemiş";
    [ObservableProperty] private string bio;
    [ObservableProperty] private string currentPassword;
    [ObservableProperty] private string newPassword;
    [ObservableProperty] private string confirmNewPassword;
    [ObservableProperty] private string profilePictureSource;

    /// <summary>
    /// Preferences üzerinden kayıtlı kullanıcı verilerini çeken metot
    /// </summary>
    private void LoadUserData()
    {
        // Kayıt (Register) sayfasında hangi anahtarlarla (Key) kaydettiysen onları çağırıyoruz
        // Eğer veri yoksa varsayılan metinleri ("...") basarız.
        FullName = Preferences.Default.Get("UserFullName", "Ad Soyad Belirtilmemiş");
        Email = Preferences.Default.Get("UserEmail", "E-posta Belirtilmemiş");
        Phone = Preferences.Default.Get("UserPhone", "Telefon Belirtilmemiş");
        Gender = Preferences.Default.Get("UserGender", "Belirtilmemiş");
        Bio = Preferences.Default.Get("UserBio", "Henüz bir biyografi eklenmemiş.");

        // Eğer daha önce bir profil resmi yolu kaydedildiyse onu çek
        ProfilePictureSource = Preferences.Default.Get("UserProfilePic", "profile_placeholder.png");
    }

    partial void OnGenderChanged(string value)
    {
        SetDefaultProfilePicture();
    }

    private void SetDefaultProfilePicture()
    {
        bool isDefault = string.IsNullOrEmpty(ProfilePictureSource) ||
                         ProfilePictureSource == "avatar_male.png" ||
                         ProfilePictureSource == "avatar_female.png" ||
                         ProfilePictureSource == "profile_placeholder.png";

        if (isDefault)
        {
            if (Gender == "Erkek") ProfilePictureSource = "avatar_male.png";
            else if (Gender == "Kadın") ProfilePictureSource = "avatar_female.png";
            else ProfilePictureSource = "profile_placeholder.png";
        }
    }

    [RelayCommand]
    private async Task ChangeProfilePictureAsync()
    {
        if (IsBusy) return;
        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions { Title = "Profil Fotoğrafı Seç" });
            if (photo == null) return;

            IsBusy = true;
            ProfilePictureSource = photo.FullPath;

            // Seçilen resim yolunu kaydet ki uygulama açılınca geri gelsin
            Preferences.Default.Set("UserProfilePic", ProfilePictureSource);

            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "Profil fotoğrafı güncellendi.", "Tamam");
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    async Task UpdateProfile()
    {
        IsBusy = true;

        // Değiştirilen bilgileri Preferences'a geri kaydet (Güncelleme işlemi)
        Preferences.Default.Set("UserFullName", FullName);
        Preferences.Default.Set("UserPhone", Phone);
        Preferences.Default.Set("UserGender", Gender);
        Preferences.Default.Set("UserBio", Bio);

        await Task.Delay(1000); // API simülasyonu
        IsBusy = false;
        await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Profil bilgileriniz başarıyla güncellendi.", "Tamam");
    }

    [RelayCommand]
    async Task UpdatePassword()
    {
        if (NewPassword != ConfirmNewPassword)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Şifreler uyuşmuyor!", "Tamam");
            return;
        }
        // Şifre güncelleme API isteği buraya gelecek
        await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Şifre başarıyla değiştirildi.", "Tamam");
    }
}