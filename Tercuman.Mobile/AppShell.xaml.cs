namespace Tercuman.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        InitializeApp();
    }

    private async void InitializeApp()
    {
        // 🔥 Direkt listings
        await GoToAsync("//listings");
    }
}
