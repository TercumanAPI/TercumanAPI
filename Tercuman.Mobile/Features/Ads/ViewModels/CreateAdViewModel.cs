using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;

namespace Tercuman.Mobile.Features.Ads.ViewModels;

public partial class CreateAdViewModel : BaseViewModel
{
    public CreateAdViewModel()
    {
        Title = "Yeni İlan Oluştur";
        Languages = new ObservableCollection<string> { "Türkçe", "Arapça", "İngilizce", "Almanca", "Fransızca" };
        Cities = new ObservableCollection<string> { "İstanbul", "Ankara", "Bursa", "Gaziantep", "İzmir" };
        ExperienceOptions = new ObservableCollection<string> { "0-1 Yıl", "1-3 Yıl", "3-5 Yıl", "5+ Yıl" };
        ServiceTypeOptions = new ObservableCollection<string> { "Sadece Online", "Yüz Yüze", "Hibrit" };
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsStep1), nameof(IsStep2), nameof(IsStep3), nameof(IsNotFirstStep))]
    [NotifyPropertyChangedFor(nameof(Step1Color), nameof(Step2Color), nameof(Step3Color))]
    [NotifyPropertyChangedFor(nameof(NextButtonText), nameof(NextButtonColor), nameof(NextButtonSpan))]
    int currentStep = 1;

    // --- XAML'DAKİ PICKER VE ENTRY'LER İÇİN GEREKLİ DEĞİŞKENLER ---
    [ObservableProperty] string sourceLanguage;
    [ObservableProperty] string targetLanguage;
    [ObservableProperty] string city;
    [ObservableProperty] string adTitle;
    [ObservableProperty] string description;
    [ObservableProperty] string price;
    [ObservableProperty] string experience;
    [ObservableProperty] string serviceType;
    // -----------------------------------------------------------

    public ObservableCollection<string> Languages { get; }
    public ObservableCollection<string> Cities { get; }
    public ObservableCollection<string> ExperienceOptions { get; }
    public ObservableCollection<string> ServiceTypeOptions { get; }

    // Görünürlük Kontrolleri
    public bool IsStep1 => CurrentStep == 1;
    public bool IsStep2 => CurrentStep == 2;
    public bool IsStep3 => CurrentStep == 3;
    public bool IsNotFirstStep => CurrentStep > 1;
    public int NextButtonSpan => CurrentStep == 1 ? 2 : 1;

    // Renk ve Metin Kontrolleri
    public Color Step1Color => CurrentStep >= 1 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");
    public Color Step2Color => CurrentStep >= 2 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");
    public Color Step3Color => CurrentStep >= 3 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");

    public string NextButtonText => CurrentStep == 3 ? "İlanı Yayınla" : "Devam Et";
    public Color NextButtonColor => CurrentStep == 3 ? Color.Parse("#22C55E") : Color.Parse("#6366F1");

    [RelayCommand]
    void Next()
    {
        if (CurrentStep < 3) CurrentStep++;
        else PublishAd();
    }

    [RelayCommand]
    void Back()
    {
        if (CurrentStep > 1) CurrentStep--;
    }

    private async void PublishAd()
    {
        await global::Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "İlanınız yayınlandı!", "Tamam");
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//DashboardPage");
    }
}