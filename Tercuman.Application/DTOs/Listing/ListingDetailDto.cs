using System;
using System.Collections.Generic;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class ListingDetailDto
    {
        public long ListingNo { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string City { get; set; } = "";

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
    }

}