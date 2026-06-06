using System;
using Microsoft.Maui.Controls;
using Tercuman.Mobile.Features.Messages.Views;
using Tercuman.Mobile.Features.Auth.Views;

namespace Tercuman.Mobile;

public partial class AppShell : Microsoft.Maui.Controls.Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Sayfa geçiþleri için sadece ALT (göreceli) rotalar buraya kaydedilir.
        // XAML içinde FlyoutItem/ShellItem olan sayfalar buraya yazýlýrsa kilitlenme yaratýr.
        Routing.RegisterRoute("CreateAdPage", typeof(Features.Ads.Views.CreateAdPage));
        Routing.RegisterRoute("ProfilePage", typeof(Features.Profile.Views.ProfilePage));
        Routing.RegisterRoute(nameof(ConversationDetailPage), typeof(ConversationDetailPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute("ListingDetail", typeof(Features.Listings.Views.ListingDetailPage));
    }

    public async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool answer = await Microsoft.Maui.Controls.Shell.Current.DisplayAlert(
            "Çýkýþ",
            "Hesabýnýzdan çýkýþ yapmak istediðinize emin misiniz?",
            "Evet",
            "Hayýr");

        if (answer)
        {
            // Tokenlarý temizle
            Preferences.Default.Remove("access_token");
            Preferences.Default.Remove("refresh_token");

            // Kilitlenmeyi önleyen mutlak yönlendirme
            await Microsoft.Maui.Controls.Shell.Current.GoToAsync("//LoginPage");
        }
    }

    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        // Sol menü altýndaki çýkýþ tetikleyicisi kontrolü
        if (args.Target.Location.OriginalString.Contains("LogoutPage"))
        {
            args.Cancel();

            bool answer = await DisplayAlert(
                "Çýkýþ",
                "Hesabýnýzdan çýkýþ yapmak istediðinize emin misiniz?",
                "Evet",
                "Hayýr");

            if (answer)
            {
                Preferences.Default.Remove("access_token");
                Preferences.Default.Remove("refresh_token");

                await GoToAsync("//LoginPage");
            }
        }
    }
}