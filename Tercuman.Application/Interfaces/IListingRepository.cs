using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Interfaces
{
    public interface IListingRepository : IGenericRepository<Listing>
    {
        Task<IEnumerable<Listing>> GetPagedAsync(int page, int pageSize);
        Task<int> CountAsync();
        Task<Listing?> GetDetailAsync(Guid id);
        Task IncrementViewCountAsync(Listing listing);
        Task AddImagesAsync(List<ListingImage> images);
    }
}