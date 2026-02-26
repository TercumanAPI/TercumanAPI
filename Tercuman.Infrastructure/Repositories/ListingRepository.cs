using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories
{
    public class ListingRepository
        : GenericRepository<Listing>, IListingRepository
    {
        public ListingRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<Listing?> GetDetailAsync(Guid id)
        {
            return await _context.Listings
                .Include(x => x.City)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task IncrementViewCountAsync(Listing listing)
        {
            listing.ViewCount++;
            _context.Listings.Update(listing);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Listing>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Listings
                .Include(x => x.City)
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
    }
}