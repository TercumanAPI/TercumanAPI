using Tercuman.Mobile.Services;

namespace Tercuman.Mobile;

public partial class AppShell : Shell
{
    private readonly AuthService _authService;

    public AppShell(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;

        InitializeApp();
    }

    private async void InitializeApp()
    {
        // 🔥 Direkt listings
        await GoToAsync("//listings");
    }
}