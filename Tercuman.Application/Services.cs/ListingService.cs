using Microsoft.EntityFrameworkCore;
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
        var listing = new Listing
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            CityId = dto.CityId,
            UserId = userId,
            ExperienceLevel = dto.ExperienceLevel,
            ServiceType = dto.ServiceType,
            SourceLanguageId = dto.SourceLanguageId,
            TargetLanguageId = dto.TargetLanguageId
        };

        await _listingRepository.AddAsync(listing);
        await _listingRepository.SaveChangesAsync();
    }

    // =========================
    // PAGED + SORT
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
            Title = listing.Title,
            Description = listing.Description,
            Price = listing.Price,
            City = listing.City?.Name ?? "",
            ViewCount = listing.ViewCount,
            CreatedDate = listing.CreatedDate,
            Images = listing.Images.Select(i => i.ImageUrl).ToList()
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
    // FILTER + PAGINATION + SORT
    // =========================
    public async Task<List<ListingDto>> FilterAsync(FilterListingDto filter)
    {
        var query = await _listingRepository.QueryAsync();

        // ================= FILTER =================
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

        // ================= SORT =================
        if (!string.IsNullOrEmpty(filter.Sort))
        {
            query = filter.Sort switch
            {
                "price_asc" => query.OrderBy(x => x.Price),
                "price_desc" => query.OrderByDescending(x => x.Price),
                _ => query
            };
        }

        // ================= PAGINATION =================
        var page = filter.Page <= 0 ? 1 : filter.Page;
        var pageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
        if (pageSize > 50) pageSize = 50;

        var listings = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return listings.Select(MapToDto).ToList();
    }

    // =========================
    // PRIVATE MAPPER
    // =========================
    private static ListingDto MapToDto(Listing x)
    {
        return new ListingDto
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            City = x.City?.Name ?? "",
            ViewCount = x.ViewCount
        };
    }
}