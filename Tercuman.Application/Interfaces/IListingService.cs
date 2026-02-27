using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Tercuman.Application.DTOs.Listing;
namespace Tercuman.Application.Interfaces
{
    public interface IListingService
    {
        Task CreateAsync(CreateListingDto dto, Guid userId);
        Task<IEnumerable<ListingDto>> GetPagedAsync(int page, int pageSize, string? sort);
        Task<int> CountAsync();
        Task<ListingDetailDto?> GetDetailAsync(Guid id);
        Task AddImagesAsync(Guid listingId, List<string> imageUrls);
        Task<List<ListingDto>> FilterAsync(FilterListingDto filter);
    }
}