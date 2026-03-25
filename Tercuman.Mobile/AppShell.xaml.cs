using Tercuman.Mobile.Services;
using Tercuman.Mobile.View;

namespace Tercuman.Mobile;

public partial class AppShell : Shell
{
    private readonly AuthService _authService;

    public AppShell(AuthService authService, LoginPage loginPage, ListingsPage listingsPage)
    {
        InitializeComponent();

        _authService = authService;

        LoginShellContent.Content = loginPage;
        ListingsShellContent.Content = listingsPage;

        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("listings", typeof(ListingsPage));
        Routing.RegisterRoute("detail", typeof(ListingDetailPage));

        _ = InitializeApp();
    }

    private async Task InitializeApp()
    {
        var isLoggedIn = await _authService.IsLoggedInAsync();

        if (isLoggedIn)
        {
            await GoToAsync("//listings");
        }
        else
        {
            await GoToAsync("//login");
        }
    }
}
