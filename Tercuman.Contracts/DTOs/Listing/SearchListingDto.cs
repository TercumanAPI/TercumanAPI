using Tercuman.Domain.Enums;

namespace Tercuman.Contracts.DTOs.Listing;

public class SearchListingDto
{
    public string? Keyword { get; set; }
    public Guid? CityId { get; set; }
    public Guid? LanguageId { get; set; }
    public ExperienceLevel? ExperienceLevel { get; set; }
    public ServiceType? ServiceType { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public double? MinRating { get; set; }
}
