using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Constants;
using Tercuman.Mobile.Features.Auth.Views;
using Tercuman.Mobile.Features.Listings.Views;
using Tercuman.Mobile.Features.Messages.Views;

namespace Tercuman.Mobile.Shell;

public partial class AppShell : Microsoft.Maui.Controls.Shell
{
    private readonly IAuthService _authService;

    public AppShell(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;

        Routing.RegisterRoute(RouteNames.Login, typeof(LoginPage));
        Routing.RegisterRoute(RouteNames.ListingDetail, typeof(ListingDetailPage));
        Routing.RegisterRoute(RouteNames.ConversationDetail, typeof(ConversationDetailPage));

        _ = InitializeAppAsync();
    }

    private async Task InitializeAppAsync()
    {
        var isAuthenticated = await _authService.IsAuthenticatedAsync();
        await GoToAsync(isAuthenticated ? "//dashboard" : "//splash");
    }
}
