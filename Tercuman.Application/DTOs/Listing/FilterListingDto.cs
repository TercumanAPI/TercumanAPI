using System;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class FilterListingDto
    {
        // FILTER
        public Guid? CityId { get; set; }
        public Guid? SourceLanguageId { get; set; }
        public Guid? TargetLanguageId { get; set; }

        // 🔥 BURAYI DÜZELTTİK
        public ServiceType? ServiceType { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // PAGINATION
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // SORT
        public string? Sort { get; set; }

        public string? SearchKeyword { get; set; }
        public string? CityName { get; set; }
        public ExperienceLevel? ExperienceLevel { get; set; }
    }
}