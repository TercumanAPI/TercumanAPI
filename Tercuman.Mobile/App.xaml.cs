namespace Tercuman.Mobile
{
    //  Microsoft.Maui.Controls ekleyerek sınıf olduğunu netleştirdik
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}