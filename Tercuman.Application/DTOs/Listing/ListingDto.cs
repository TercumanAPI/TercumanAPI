using System;
using Tercuman.Domain.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class ListingDto
    {
        public long ListingNo { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CityId { get; set; }

        // SADECE BUNU KULLAN
        public string City { get; set; }

        public string TranslatorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;


        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }

        public string SourceLanguageName { get; set; } = "";
        public string TargetLanguageName { get; set; } = "";


        public ServiceType ServiceType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }

        public int ViewCount { get; set; }
        public string? TranslatorPhotoUrl { get; set; }

        //public string ListingNo => Id.ToString().Substring(0, 8);

    }
}