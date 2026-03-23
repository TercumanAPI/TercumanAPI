using Tercuman.Mobile.ViewModels;
using Tercuman.Contracts.DTOs.Listing;


namespace Tercuman.Mobile.View;

public partial class ListingsPage : ContentPage
{
    public ListingsPage(ListingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListingsViewModel vm && vm.Listings.Count == 0)
        {
            await vm.LoadListingsCommand.ExecuteAsync(null);
        }
    }
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as ListingDto;

        if (item == null)
            return;

        await Shell.Current.GoToAsync("detail", new Dictionary<string, object>
        {
            { "listing", item }
        });
    }
}
