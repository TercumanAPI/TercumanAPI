namespace Tercuman.Mobile.Features.Splash;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // 2 saniye bekleme süresi (Görsel þölen için)
        await Task.Delay(2000);

        // Ana sayfaya uçuþ (AppShell'e geçiþ)
        Application.Current.MainPage = new AppShell();
    }
}