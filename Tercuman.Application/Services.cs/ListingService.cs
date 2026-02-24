using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public async Task CreateAsync(CreateListingDto dto, Guid userId)
        {
            var listing = new Listing
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                CityId = dto.CityId,
                UserId = userId
            };

            await _listingRepository.AddAsync(listing);
            await _listingRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListingDto>> GetPagedAsync(int page, int pageSize)
        {
            var listings = await _listingRepository.GetPagedAsync(page, pageSize);

            return listings.Select(x => new ListingDto
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                City = x.City.Name,
                ViewCount = x.ViewCount
            });
        }

        public async Task<int> CountAsync()
        {
            return await _listingRepository.CountAsync();
        }

        public async Task<ListingDetailDto?> GetDetailAsync(Guid id)
        {
            var listing = await _listingRepository.GetDetailAsync(id);

            if (listing == null)
                return null;

            return new ListingDetailDto
            {
                Id = listing.Id,
                Title = listing.Title,
                Description = listing.Description,
                Price = listing.Price,
                City = listing.City.Name,   
                ViewCount = listing.ViewCount,
                Images = listing.Images?.Select(i => i.ImageUrl).ToList()
            };
        }
    }
}
