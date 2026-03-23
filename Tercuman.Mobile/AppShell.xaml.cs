using Tercuman.Mobile.Services;
using Tercuman.Mobile.View;

namespace Tercuman.Mobile;

public partial class AppShell : Shell
{
    private readonly AuthService _authService;

    public AppShell(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;

        Routing.RegisterRoute("detail", typeof(ListingDetailPage));

        InitializeApp();
    }

    private async void InitializeApp()
    {
        //  Direkt listings açılıyor, eğer kullanıcı giriş yapmamışsa Login sayfasına yönlendiriliyor.
        await GoToAsync("//listings");
    }
}