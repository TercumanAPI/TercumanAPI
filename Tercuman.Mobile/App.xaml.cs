using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace Tercuman.Mobile;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = default!;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        Services = serviceProvider;

        try
        {
            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
