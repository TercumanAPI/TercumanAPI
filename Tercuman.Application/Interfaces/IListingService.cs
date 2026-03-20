using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Application.Interfaces
{
    public interface IListingService
    {
        Task CreateAsync(CreateListingDto dto, Guid userId);
        Task<IEnumerable<ListingDto>> GetPagedAsync(int page, int pageSize, string? sort);
        Task<int> CountAsync();
        Task<ListingDetailDto?> GetDetailAsync(Guid id);
        Task AddImagesAsync(Guid listingId, List<string> imageUrls);
        Task<PagedResultDto<ListingDto>> FilterAsync(FilterListingDto filter);
        Task<List<ListingListDto>> SearchAsync(string keyword);
        Task<List<ListingListDto>> SearchAsync(SearchListingDto search);
        Task IncrementViewAsync(Guid listingId, Guid? userId, string? ipAddress);
    }
}