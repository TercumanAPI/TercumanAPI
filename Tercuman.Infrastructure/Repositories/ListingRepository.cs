using Microsoft.EntityFrameworkCore;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories;

public class ListingRepository
    : GenericRepository<Listing>, IListingRepository
{
    private readonly AppDbContext _context;

    public ListingRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Listing?> GetDetailAsync(Guid id)
    {
        return await _context.Listings
            .Include(x => x.City)
            .Include(x => x.Images)
            .Include(x => x.User)
            .Include(x => x.SourceLanguage)     
            .Include(x => x.TargetLanguage)     
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<List<Listing>> GetPagedAsync(int page, int pageSize)
    {
        return await _context.Listings
            .Include(x => x.City)
            .Include(x => x.User)
            .Include(x => x.SourceLanguage)
            .Include(x => x.TargetLanguage)
            .Where(x => x.IsActive && x.IsApproved && !x.IsDeleted)
            .OrderByDescending(x => x.CreatedDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Listings
            .CountAsync(x => x.IsActive && x.IsApproved && !x.IsDeleted);
    }

    public IQueryable<Listing> Query()
    {
        return _context.Listings
            .Include(x => x.City)
            .Include(x => x.User)
            .Include(x => x.SourceLanguage)
            .Include(x => x.TargetLanguage)
            .Where(x => x.IsActive && x.IsApproved && !x.IsDeleted);
    }

    public async Task<List<Listing>> SearchAsync(string keyword)
    {
        return await _context.Listings
            .Include(x => x.City)
            .Where(x =>
                x.Title.Contains(keyword) ||
                x.Description.Contains(keyword))
            .ToListAsync();
    }
    public async Task AddImagesAsync(List<ListingImage> images)
    {
        await _context.ListingImages.AddRangeAsync(images);
        await _context.SaveChangesAsync();
    }
}