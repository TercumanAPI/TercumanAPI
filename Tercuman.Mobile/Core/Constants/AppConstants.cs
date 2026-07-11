using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Core.Constants;

public static class AppConstants
{
    // --- BACKEND AppDbContext'TEN GELEN TÜM DİLLER (50 ADET) ---
    public static readonly List<string> Languages = new()
    {
        "Türkçe", "Arapça", "İngilizce", "Almanca", "Fransızca", "İspanyolca", "İtalyanca", "Rusça", "Çince", "Japonca",
        "Korece", "Portekizce", "Hollandaca", "Yunanca", "Farsça", "Hintçe", "Urduca", "İbranice", "İsveççe", "Norveççe",
        "Danca", "Fince", "Lehçe", "Macarca", "Romence", "Bulgarca", "Sırpça", "Hırvatça", "Boşnakça", "Arnavutça",
        "Ukraynaca", "Gürcüce", "Ermenice", "Tayca", "Vietnamca", "Malayca", "Endonezce", "Svahili", "Afrikanca", "Amharca",
        "Azerice", "Kazakça", "Özbekçe", "Türkmence", "Kürtçe", "Peştuca", "Bengalce", "Tamilce", "Teluguca"
    };

    // --- BACKEND AppDbContext'TEN GELEN TÜM ŞEHİRLER (81 ADET) ---
    public static readonly List<string> Cities = new()
    {
        "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
        "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
        "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
        "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
        "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
        "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
        "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
        "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
    };

    // Diğer Sabit Seçenekler
    public static readonly List<string> ExperienceOptions = new() { "0-1 Yıl", "1-3 Yıl", "3-5 Yıl", "5+ Yıl" };
    public static readonly List<string> ServiceTypeOptions = new() { "Sadece Online", "Yüz Yüze", "Hibrit" };
}
