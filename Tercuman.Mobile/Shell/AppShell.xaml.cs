using Tercuman.Mobile.Features.Messages.Views;
using Tercuman.Mobile.Features.Auth.Views;

namespace Tercuman.Mobile;

public partial class AppShell : Microsoft.Maui.Controls.Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Sayfa geçiþleri için rotalar
        Routing.RegisterRoute("CreateAdPage", typeof(Features.Ads.Views.CreateAdPage));
        Routing.RegisterRoute("ProfilePage", typeof(Features.Profile.Views.ProfilePage));
        Routing.RegisterRoute(nameof(ConversationDetailPage), typeof(ConversationDetailPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));

        // Çýkýþ iþlemini yakalamak için sanal bir rota tanýmý
        Routing.RegisterRoute("LogoutPage", typeof(LoginPage));
    }
    public async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Tam yol belirterek çakýþmayý önlüyoruz
        bool answer = await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Çýkýþ", "Hesabýnýzdan çýkýþ yapmak istediðinize emin misiniz?", "Evet", "Hayýr");

        if (answer)
        {
            // Tokenlarý temizle
            Preferences.Default.Remove("access_token");
            Preferences.Default.Remove("refresh_token");

            // Kesin yönlendirme
            await Microsoft.Maui.Controls.Shell.Current.GoToAsync("//LoginPage");
        }
    }
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        // LogoutPage kontrolü
        if (args.Target.Location.OriginalString.Contains("LogoutPage"))
        {
            // Kullanýcý zaten LoginPage'e yönleneceði için iþlemi burada kesip onay alýyoruz
            args.Cancel();

            bool answer = await DisplayAlert("Çýkýþ", "Hesabýnýzdan çýkýþ yapmak istediðinize emin misiniz?", "Evet", "Hayýr");

            if (answer)
            {
                Preferences.Default.Remove("access_token");
                Preferences.Default.Remove("refresh_token");

                // Kesin çýkýþ ve yönlendirme
                await GoToAsync("//LoginPage");
            }
        }
    }
}