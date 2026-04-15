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
        // AppShell.xaml.cs içinde Constructor'a ekle:
        Routing.RegisterRoute("ProfilePage", typeof(Features.Profile.Views.ProfilePage));
        Routing.RegisterRoute(nameof(ConversationDetailPage), typeof(ConversationDetailPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    }
}