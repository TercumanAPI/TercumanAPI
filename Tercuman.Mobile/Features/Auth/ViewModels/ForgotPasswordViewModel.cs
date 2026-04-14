using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;

namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class ForgotPasswordViewModel : BaseViewModel
{
    [ObservableProperty]
    private string email;

    [RelayCommand]
    private async Task SendResetLink()
    {
        // 'this.' kullanarak isim çakışmalarını (CS0119) önlüyoruz
        if (string.IsNullOrWhiteSpace(this.Email))
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Uyarı", "Lütfen e-posta adresinizi girin.", "Tamam");
            return;
        }

        IsBusy = true;
        try
        {
            // API simülasyonu
            await Task.Delay(1000);

            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Bilgi", "Sıfırlama bağlantısı e-posta adresinize gönderildi.", "Tamam");
            await Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "İşlem başarısız: " + ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    // XAML'deki 'GoBackCommand' hatasını çözen kısım:
    [RelayCommand]
    private async Task GoBack()
    {
        // Giriş sayfasına geri döner
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
    }
}