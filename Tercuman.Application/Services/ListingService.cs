using Microsoft.EntityFrameworkCore;
using Tercuman.Application.DTOs.Common;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.Exceptions;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Domain.Enums;

namespace Tercuman.Application.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;
    private readonly IGenericRepository<ListingView> _listingViewRepository;
    private readonly IGenericRepository<Review> _reviewRepository;

    public ListingService(IListingRepository listingRepository, IGenericRepository<ListingView> listingViewRepository, IGenericRepository<Review> reviewRepository)
    {
        _listingRepository = listingRepository;
        _listingViewRepository = listingViewRepository;
        _reviewRepository = reviewRepository;
    }

    // =========================
    // CREATE
    // =========================
    public async Task CreateAsync(CreateListingDto dto, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ValidationException("Title boş olamaz");

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

            Name = string.IsNullOrWhiteSpace(dto.Name) ? dto.Title : dto.Name,
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
        var currentPage = page <= 0 ? 1 : page;
        var currentPageSize = pageSize <= 0 ? 10 : pageSize;
        if (currentPageSize > 50)
            currentPageSize = 50;

        var query = _listingRepository.Query();

        if (!string.IsNullOrEmpty(sort))
        {
            query = sort switch
            {
                "price_asc" => query.OrderBy(x => x.Price),
                "price_desc" => query.OrderByDescending(x => x.Price),
                _ => query
            };
        }
        else
        {
            query = query.OrderByDescending(x => x.CreatedDate);
        }

        var listings = await query
            .Skip((currentPage - 1) * currentPageSize)
            .Take(currentPageSize)
            .ToListAsync();

        return listings.Select(MapToDto).ToList();
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
    public async Task<PagedResultDto<ListingDto>> FilterAsync(FilterListingDto filter)
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
                (x.City != null ? x.City.Name : string.Empty).ToLower().Contains(city));
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

        if (filter.Gender.HasValue)
            query = query.Where(x => x.User != null && x.User.Gender == filter.Gender.Value);

        var totalCount = await query.CountAsync();

        var listings = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResultDto<ListingDto>
        {
            Items = listings.Select(MapToDto).ToList(),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
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

            Name = x.Name,
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
            PhoneNumber = x.User?.PhoneNumber ?? "",
            TranslatorPhotoUrl = x.User != null ? x.User.ProfileImageUrl : null
        };
    }
    // =========================
    // SEARCH
    public async Task<List<ListingListDto>> SearchAsync(string keyword)
    {
        return await SearchAsync(new SearchListingDto { Keyword = keyword });
    }

    public async Task<List<ListingListDto>> SearchAsync(SearchListingDto search)
    {
        var query = _listingRepository.Query();

        if (!string.IsNullOrWhiteSpace(search.Keyword))
        {
            var keyword = search.Keyword.ToLower();
            query = query.Where(x => x.Title.ToLower().Contains(keyword) || x.Description.ToLower().Contains(keyword));
        }

        if (search.CityId.HasValue)
            query = query.Where(x => x.CityId == search.CityId.Value);

        if (search.LanguageId.HasValue)
            query = query.Where(x => x.SourceLanguageId == search.LanguageId.Value || x.TargetLanguageId == search.LanguageId.Value);

        if (search.ExperienceLevel.HasValue)
            query = query.Where(x => x.ExperienceLevel == search.ExperienceLevel.Value);

        if (search.ServiceType.HasValue)
            query = query.Where(x => x.ServiceType == search.ServiceType.Value);

        if (search.MinPrice.HasValue)
            query = query.Where(x => x.Price >= search.MinPrice.Value);

        if (search.MaxPrice.HasValue)
            query = query.Where(x => x.Price <= search.MaxPrice.Value);

        var listings = await query
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();

        if (search.MinRating.HasValue)
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var avgRatingsByListing = reviews
                .GroupBy(r => r.ListingId)
                .ToDictionary(g => g.Key, g => g.Average(r => r.Rating));

            listings = listings
                .Where(x => avgRatingsByListing.TryGetValue(x.Id, out var avgRating) && avgRating >= search.MinRating.Value)
                .ToList();
        }

        return listings.Select(MapToListDto).ToList();
    }


    private static ListingListDto MapToListDto(Listing x)
    {
        return new ListingListDto
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            CityName = x.City?.Name ?? string.Empty
        };
    }

    public async Task IncrementViewAsync(Guid listingId, Guid? userId, string? ipAddress)
    {
        var listing = await _listingRepository.GetByIdAsync(listingId);

        if (listing == null || listing.IsDeleted)
            throw new ValidationException("Listing bulunamadı");

        listing.ViewCount++;
        _listingRepository.Update(listing);

        var view = new ListingView
        {
            ListingId = listingId,
            UserId = userId,
            IpAddress = ipAddress ?? string.Empty,
            CreatedDate = DateTime.UtcNow
        };

        await _listingViewRepository.AddAsync(view);
        await _listingRepository.SaveChangesAsync();
    }
}
