using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Features.Home.Models;
using Tercuman.Mobile.Core.Constants; // AppConstants'a erişmek için şart

namespace Tercuman.Mobile.Features.Home.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    // --- LİSTELER (Picker'lar için) ---
    public ObservableCollection<string> Languages { get; }
    public ObservableCollection<string> Cities { get; }
    public ObservableCollection<string> ExperienceOptions { get; }
    public ObservableCollection<string> ServiceTypeOptions { get; }
    public ObservableCollection<string> GenderOptions { get; } // AppConstants'ta yoksa "Erkek", "Kadın" olarak eklenebilir

    // --- SEÇİLİ FİLTRELER ---
    [ObservableProperty] private string _selectedSourceLanguage;
    [ObservableProperty] private string _selectedTargetLanguage;
    [ObservableProperty] private string _selectedCity;
    [ObservableProperty] private string _selectedExperience;
    [ObservableProperty] private string _searchQuery;
    [ObservableProperty] private string _selectedGender;
    [ObservableProperty] private string _selectedServiceType;

    [ObservableProperty]
    private ObservableCollection<TranslatorModel> _translators;

    public HomeViewModel()
    {
        // Mevcutların altına ekle
        Languages = new ObservableCollection<string>(AppConstants.Languages);
        Cities = new ObservableCollection<string>(AppConstants.Cities);
        ExperienceOptions = new ObservableCollection<string>(AppConstants.ExperienceOptions);
        ServiceTypeOptions = new ObservableCollection<string>(AppConstants.ServiceTypeOptions);

        // Cinsiyet sabit değilse el ile de ekleyebilirsin
        GenderOptions = new ObservableCollection<string> { "Erkek", "Kadın", "Hepsi" };

        Translators = new ObservableCollection<TranslatorModel>();
        LoadMockData();
    }

    [RelayCommand]
    private async Task Search()
    {
        // Arama butonuna basınca çalışacak mantık
    }

    [RelayCommand]
    private void ApplyFilters()
    {
        // Filtreleri uygula butonuna basınca çalışacak mantık
        // SelectedSourceLanguage, SelectedCity gibi değerleri kullanarak listeyi süzebilirsin
    }

    private void LoadMockData()
    {
        // Burası şimdilik boş kalabilir veya test verisi eklenebilir
    }
}