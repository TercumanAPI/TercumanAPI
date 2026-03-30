
namespace Tercuman.Mobile;


public partial class AppShell : Microsoft.Maui.Controls.Shell
{
	public AppShell()
	{
		InitializeComponent();
        // Sayfa geçiþleri için rotalar
        Routing.RegisterRoute("CreateAdPage", typeof(Features.Ads.Views.CreateAdPage));
    }
}