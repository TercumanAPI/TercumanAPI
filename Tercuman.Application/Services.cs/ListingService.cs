using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;

    public ListingService(IListingRepository listingRepository)
    {
        _listingRepository = listingRepository;
    }

    // =========================
    // CREATE
    // =========================
    public async Task CreateAsync(CreateListingDto dto, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new Exception("Title boş olamaz");

        var random = new Random();
        long listingNo;

        // aynı numara varsa tekrar üret
        do
        {
            listingNo = random.NextInt64(1000000000, 9999999999);
        }
        while (await _listingRepository.Query()
            .AnyAsync(x => x.ListingNo == listingNo));

        var listing = new Listing
        {
            ListingNo = listingNo,

            Name = dto.Title,
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,

            CityId = dto.CityId,
            UserId = userId,

            ExperienceLevel = dto.ExperienceLevel,
            ServiceType = dto.ServiceType,

            SourceLanguageId = dto.SourceLanguageId,
            TargetLanguageId = dto.TargetLanguageId,

            CreatedDate = DateTime.UtcNow
        };

        await _listingRepository.AddAsync(listing);
        await _listingRepository.SaveChangesAsync();
    }

    // =========================
    // PAGED
    // =========================
    public async Task<IEnumerable<ListingDto>> GetPagedAsync(int page, int pageSize, string? sort)
    {
        var listings = await _listingRepository.GetPagedAsync(page, pageSize);
        var query = listings.AsQueryable();

        if (!string.IsNullOrEmpty(sort))
        {
            query = sort switch
            {
                "price_asc" => query.OrderBy(x => x.Price),
                "price_desc" => query.OrderByDescending(x => x.Price),
                _ => query
            };
        }

        return query.Select(MapToDto).ToList();
    }

    // =========================
    // COUNT
    // =========================
    public async Task<int> CountAsync()
    {
        return await _listingRepository.CountAsync();
    }

    // =========================
    // DETAIL
    // =========================
    public async Task<ListingDetailDto?> GetDetailAsync(Guid id)
    {
        var listing = await _listingRepository.GetDetailAsync(id);

        if (listing == null)
            return null;

        listing.ViewCount++;

        _listingRepository.Update(listing);
        await _listingRepository.SaveChangesAsync();

        return new ListingDetailDto
        {
            Id = listing.Id,
            UserId = listing.UserId,
            ListingNo = listing.ListingNo,
            UserPhone = listing.User?.PhoneNumber ?? "",

            Title = listing.Title,
            Description = listing.Description,
            Price = listing.Price,

            City = listing.City?.Name ?? "",

            ViewCount = listing.ViewCount,
            CreatedAt = listing.CreatedDate,

            UserFullName = listing.User?.FullName ?? "",
            Gender = listing.User?.Gender.ToString() ?? "",
            UserCreatedAt = listing.User?.CreatedDate ?? DateTime.MinValue,

            Images = listing.Images?
                .Select(i => i.ImageUrl)
                .ToList() ?? new List<string>(),

            ExperienceLevel = listing.ExperienceLevel,
            ServiceType = listing.ServiceType,

            SourceLanguageId = listing.SourceLanguageId,
            TargetLanguageId = listing.TargetLanguageId
        };
    }

    // =========================
    // ADD IMAGES
    // =========================
    public async Task AddImagesAsync(Guid listingId, List<string> imageUrls)
    {
        var images = imageUrls.Select(url => new ListingImage
        {
            ListingId = listingId,
            ImageUrl = url
        }).ToList();

        await _listingRepository.AddImagesAsync(images);
    }

    // =========================
    // FILTER
    // =========================
    public async Task<List<ListingDto>> FilterAsync(FilterListingDto filter)
    {
        var query = _listingRepository.Query();

        if (!string.IsNullOrWhiteSpace(filter.SearchKeyword))
        {
            var keyword = filter.SearchKeyword.ToLower();

            query = query.Where(x =>
                x.Title.ToLower().Contains(keyword) ||
                x.Description.ToLower().Contains(keyword) ||
                x.User.FullName.ToLower().Contains(keyword) ||
                x.ListingNo.ToString().Contains(keyword));
        }

        if (!string.IsNullOrWhiteSpace(filter.CityName))
        {
            var city = filter.CityName.ToLower();

            query = query.Where(x =>
                x.City.Name.ToLower().Contains(city));
        }

        if (filter.ExperienceLevel.HasValue)
        {
            query = query.Where(x =>
                x.ExperienceLevel == filter.ExperienceLevel.Value);
        }

        if (filter.CityId.HasValue)
            query = query.Where(x => x.CityId == filter.CityId.Value);

        if (filter.SourceLanguageId.HasValue)
            query = query.Where(x => x.SourceLanguageId == filter.SourceLanguageId.Value);

        if (filter.TargetLanguageId.HasValue)
            query = query.Where(x => x.TargetLanguageId == filter.TargetLanguageId.Value);

        if (filter.ServiceType.HasValue)
            query = query.Where(x => x.ServiceType == filter.ServiceType.Value);

        if (filter.MinPrice.HasValue)
            query = query.Where(x => x.Price >= filter.MinPrice.Value);

        if (filter.MaxPrice.HasValue)
            query = query.Where(x => x.Price <= filter.MaxPrice.Value);

        if (!string.IsNullOrEmpty(filter.Sort))
        {
            query = filter.Sort switch
            {
                "price_asc" => query.OrderBy(x => x.Price),
                "price_desc" => query.OrderByDescending(x => x.Price),
                _ => query
            };
        }

        var page = filter.Page <= 0 ? 1 : filter.Page;
        var pageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;

        if (pageSize > 50)
            pageSize = 50;

        var listings = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return listings.Select(MapToDto).ToList();
    }

    // =========================
    // MAPPER
    // =========================
    private static ListingDto MapToDto(Listing x)
    {
        return new ListingDto
        {
            Id = x.Id,
            UserId = x.UserId,
            ListingNo = x.ListingNo,

            Title = x.Title,
            Description = x.Description,
            Price = x.Price,

            CityId = x.CityId,
            City = x.City?.Name ?? "",

            SourceLanguageId = x.SourceLanguageId,
            TargetLanguageId = x.TargetLanguageId,

            SourceLanguageName = x.SourceLanguage?.Name ?? "",
            TargetLanguageName = x.TargetLanguage?.Name ?? "",

            ServiceType = x.ServiceType,
            ExperienceLevel = x.ExperienceLevel,

            ViewCount = x.ViewCount,
            CreatedAt = x.CreatedDate,

            TranslatorName = x.User?.FullName ?? "",
            Gender = x.User?.Gender.ToString() ?? "",
            Phone = x.User?.PhoneNumber ?? ""
        };
    }
    // =========================
    // SEARCH
    public async Task<List<ListingListDto>> SearchAsync(string keyword)
    {
        var listings = await _listingRepository.SearchAsync(keyword);

        return listings.Select(x => new ListingListDto
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            CityName = x.City.Name
        }).ToList();
    }
}