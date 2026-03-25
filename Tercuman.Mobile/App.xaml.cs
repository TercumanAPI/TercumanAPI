using Microsoft.Maui.Controls;

namespace Tercuman.Mobile;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = default!;

    public App(IServiceProvider serviceProvider)
    {
        // --- BURAYA YAPIŞTIRIN ---
        var names = typeof(App).Assembly.GetManifestResourceNames();
        System.Diagnostics.Debug.WriteLine("Manifest resources:\n" + string.Join("\n", names));
        // -------------------------
        InitializeComponent();

        Services = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        //  DI ile AppShell oluştur
        MainPage = serviceProvider.GetRequiredService<AppShell>();
    }
}