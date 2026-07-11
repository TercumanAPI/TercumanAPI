namespace Tercuman.Mobile.Base;

public partial class BasePage : ContentPage
{
    public BasePage()
    {
        Content = new VerticalStackLayout
    {
        Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
                }
        }
    };
    }
}