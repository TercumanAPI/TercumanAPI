using Tercuman.Mobile.View;

namespace Tercuman.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("listings", typeof(ListingsPage));
        Routing.RegisterRoute("detail", typeof(ListingDetailPage));
    }
}
