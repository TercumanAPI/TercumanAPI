
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
    }
}