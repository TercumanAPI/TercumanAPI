using System;
using System.Collections.Generic;
using Tercuman.Domain.Enums;

namespace Tercuman.Contracts.DTOs.Listing
{
    public class ListingDetailDto
    {
        // =========================================================================
        // 1. BACKEND ORİJİNAL ALANLARI (Hiçbir Şey Silinmedi veya Değiştirilmedi)
        // =========================================================================
        public long ListingNo { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string City { get; set; } = "";
        public string UserPhone { get; set; } = "";

        // User bilgileri
        public string UserFullName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime UserCreatedAt { get; set; }

        // Listing bilgileri
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Images { get; set; } = new();
        public ExperienceLevel ExperienceLevel { get; set; }
        public ServiceType ServiceType { get; set; }
        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }
        public string? TranslatorPhotoUrl { get; set; }

        // =========================================================================
        // 2. MOBİL ARAYÜZ VE EKSTRA UI ALANLARI (Üstüne Eklendi)
        // =========================================================================
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; } = "";
        public string CityName { get; set; } = "";
        public string Languages { get; set; } = ""; // "Türkçe - Arapça" gibi arayüz birleştirmeleri için
        public string Experience { get; set; } = ""; // Enum'ı metne çevirmek için

        // İlan Sahibi Bilgileri (Alternatif UI İsimlendirmeleri)
        public string OwnerFullName { get; set; } = "";
        public string OwnerPhoneNumber { get; set; } = "";
        public string OwnerCreatedDateText { get; set; } = "";
    }
}