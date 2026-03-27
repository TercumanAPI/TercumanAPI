namespace Tercuman.Mobile;

public partial class App : Application
{
    public App(Shell.AppShell shell)
    {
        InitializeComponent();
        MainPage = shell;
    }
}
