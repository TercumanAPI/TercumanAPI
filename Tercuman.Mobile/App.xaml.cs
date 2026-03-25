using Microsoft.Maui.Controls;

namespace Tercuman.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}
