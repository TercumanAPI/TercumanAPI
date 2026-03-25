using System;
using System.Collections.Generic;
using Tercuman.Domain.Enums;

namespace Tercuman.Contracts.DTOs.Listing
{
    public class ListingDetailDto
    {
        public long ListingNo { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string City { get; set; } = string.Empty;

        public string UserPhone { get; set; } = "";

        //  User bilgileri
        public string UserFullName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime UserCreatedAt { get; set; }

        //  Listing bilgileri
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Images { get; set; } = new();
        public ExperienceLevel ExperienceLevel { get; set; }
        public ServiceType ServiceType { get; set; }
        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }
        public string? TranslatorPhotoUrl { get; set; }
    }

}
