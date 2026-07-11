using Microsoft.EntityFrameworkCore;
using Tercuman.Application.DTOs.Favorite;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAsync(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid listingId)
        {
            return await _context.Favorites.AnyAsync(f => f.UserId == userId && f.ListingId == listingId);
        }

        public async Task<Favorite?> GetFavoriteAsync(Guid userId, Guid listingId)
        {
            return await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.ListingId == listingId);
        }

        public async Task<List<FavoriteItemDto>> GetUserFavoritesAsync(Guid userId)
        {
            return await _context.Favorites
                .AsNoTracking()
                .Where(f => f.UserId == userId)
                .Select(f => new FavoriteItemDto
                {
                    FavoriteId = f.Id,
                    ListingId = f.ListingId,
                    ListingNo = f.Listing.ListingNo,
                    Title = f.Listing.Title ?? f.Listing.Name ?? string.Empty,
                    Description = f.Listing.Description,
                    Price = f.Listing.Price,
                    TranslatorName = f.Listing.User.FullName,
                    TranslatorEmail = f.Listing.User.Email,
                    TranslatorPhoneNumber = f.Listing.User.PhoneNumber,
                    TranslatorProfileImageUrl = f.Listing.User.ProfileImageUrl,
                    City = f.Listing.City != null ? f.Listing.City.Name : null,
                    CreatedDate = f.CreatedDate
                })
                .ToListAsync();
        }
    }
}