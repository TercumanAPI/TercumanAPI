using System.Collections.ObjectModel;
using System.Linq;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Constants; // Sabitleri kullanmak için ekledik

namespace Tercuman.Mobile.Features.Ads.ViewModels;

public partial class CreateAdViewModel : BaseViewModel
{
    public CreateAdViewModel()
    {
        Title = "Yeni İlan Oluştur";

        // VERİLERİ APPCONSTANTS ÜZERİNDEN PAKET OLARAK ÇEKİYORUZ
        Languages = new ObservableCollection<string>(AppConstants.Languages);
        Cities = new ObservableCollection<string>(AppConstants.Cities);
        ExperienceOptions = new ObservableCollection<string>(AppConstants.ExperienceOptions);
        ServiceTypeOptions = new ObservableCollection<string>(AppConstants.ServiceTypeOptions);
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsStep1), nameof(IsStep2), nameof(IsStep3), nameof(IsNotFirstStep))]
    [NotifyPropertyChangedFor(nameof(Step1Color), nameof(Step2Color), nameof(Step3Color))]
    [NotifyPropertyChangedFor(nameof(Step1LineColor), nameof(Step2LineColor))] // Çizgi renkleri tetiklemesi
    [NotifyPropertyChangedFor(nameof(NextButtonText), nameof(NextButtonColor), nameof(NextButtonSpan))]
    int currentStep = 1;

    // --- FORM DEĞİŞKENLERİ ---
    [ObservableProperty] string sourceLanguage;
    [ObservableProperty] string targetLanguage;
    [ObservableProperty] string city;
    [ObservableProperty] string adTitle;
    [ObservableProperty] string description;
    [ObservableProperty] string experience;
    [ObservableProperty] string serviceType;

    // --- FİYAT FORMATLAMA (1.250 gibi nokta ekler) ---
    [ObservableProperty] string price;
    partial void OnPriceChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;

        var digitsOnly = new string(value.Where(char.IsDigit).ToArray());
        if (double.TryParse(digitsOnly, out double amount))
        {
            var formatted = amount.ToString("N0", new CultureInfo("tr-TR"));
            if (Price != formatted)
            {
                Price = formatted;
            }
        }
    }

    public ObservableCollection<string> Languages { get; }
    public ObservableCollection<string> Cities { get; }
    public ObservableCollection<string> ExperienceOptions { get; }
    public ObservableCollection<string> ServiceTypeOptions { get; }

    // --- GÖRÜNÜRLÜK KONTROLLERİ ---
    public bool IsStep1 => CurrentStep == 1;
    public bool IsStep2 => CurrentStep == 2;
    public bool IsStep3 => CurrentStep == 3;
    public bool IsNotFirstStep => CurrentStep > 1;
    public int NextButtonSpan => CurrentStep == 1 ? 2 : 1;

    // --- RENK KONTROLLERİ (Daireler) ---
    public Color Step1Color => CurrentStep >= 1 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");
    public Color Step2Color => CurrentStep >= 2 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");
    public Color Step3Color => CurrentStep >= 3 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");

    // --- ÇİZGİ RENKLERİ (BoxViewlar) ---
    public Color Step1LineColor => CurrentStep >= 2 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");
    public Color Step2LineColor => CurrentStep >= 3 ? Color.Parse("#22C55E") : Color.Parse("#E2E8F0");

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