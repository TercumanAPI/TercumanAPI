using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Mobile.Features.Listings.Models;
using Microsoft.Maui.Controls;

namespace Tercuman.Mobile.Features.Listings.ViewModels;

[QueryProperty(nameof(ListingId), "listingId")]
public partial class ListingDetailViewModel : ObservableObject
{
    private readonly HttpClient _httpClient; 

    [ObservableProperty]
    private string listingId;

    [ObservableProperty]
    private ListingDetailDto listing;

    [ObservableProperty]
    private bool isLoading;

    // YENİ: Ekranda dönen yenileme animasyonunu (RefreshView) yönetecek değişken
    [ObservableProperty]
    private bool isRefreshing;

    public ListingDetailViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // ListingId dışarıdan set edildiğinde otomatik tetiklenir
    partial void OnListingIdChanged(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _ = LoadListingDetailsAsync(value);
        }
    }

    private async Task LoadListingDetailsAsync(string id)
    {
        IsLoading = true;
        try
        {
            // 1. Backend'deki endpoint'ine istek atıyoruz
            var response = await _httpClient.GetAsync($"api/listings/{id}");

            if (response.IsSuccessStatusCode)
            {
                // 2. Gelen JSON verisini otomatik olarak modeline çeviriyoruz
                Listing = await response.Content.ReadFromJsonAsync<ListingDetailDto>();
            }
            else
            {
                // Sunucu hata döndürürse (404 Bulunamadı vb.) kullanıcıya gösteriyoruz
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert(
                    "Hata",
                    "İlan detayları sunucudan alınamadı.",
                    "Tamam");
            }
        }
        catch (Exception ex)
        {
            // İnternet kopması veya sunucu çökmesi durumunda burası çalışır
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert(
                "Bağlantı Hatası",
                $"Sunucuya bağlanılamadı: {ex.Message}",
                "Tamam");
        }
        finally
        {
            IsLoading = false;
        }
    }

    // YENİ: Kullanıcı ekranı aşağı çektiğinde çalışacak olan komut
    [RelayCommand]
    private async Task RefreshAsync()
    {
        IsRefreshing = true; // Animasyonu başlat

        try
        {
            if (!string.IsNullOrEmpty(ListingId))
            {
                await LoadListingDetailsAsync(ListingId); // Verileri baştan çek
            }
        }
        finally
        {
            IsRefreshing = false; // İşlem bitince animasyonu durdur
        }
    }

    [RelayCommand]
    private async Task SendMessageAsync()
    {
        if (Listing == null) return;

        // Mesajlaşma sayfasına ilan sahibinin bilgisini göndererek yönlendirir
        await Microsoft.Maui.Controls.Shell.Current.GoToAsync($"//Messages/ConversationDetail?userId={Listing.OwnerFullName}");
    }
}