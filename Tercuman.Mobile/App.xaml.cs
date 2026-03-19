using Microsoft.Maui.Controls;

namespace Tercuman.Mobile;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = default!;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        Services = serviceProvider;

        // 🔥 DI ile AppShell oluştur
        MainPage = serviceProvider.GetRequiredService<AppShell>();
    }
}