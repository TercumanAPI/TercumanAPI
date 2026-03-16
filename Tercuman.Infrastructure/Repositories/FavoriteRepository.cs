using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tercuman.Application.Interfaces; // Bu satır eksikti
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

        public async Task<IEnumerable<Favorite>> GetUserFavoritesAsync(Guid userId)
        {
            return await _context.Favorites
                .Include(f => f.Listing)
                    .ThenInclude(l => l.User) // Frontend'in beklediği Tercüman bilgisi için bu satırı ekledik
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}