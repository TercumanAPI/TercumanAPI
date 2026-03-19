using Tercuman.Mobile.ViewModels;

namespace Tercuman.Mobile.View;

public partial class ListingsPage : ContentPage
{
    public ListingsPage(ListingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = App.Services.GetService<ListingsViewModel>();
    }
    

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListingsViewModel vm && vm.Listings.Count == 0)
        {
            await vm.LoadListingsCommand.ExecuteAsync(null);
        }
    }
}