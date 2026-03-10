using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Interfaces;


public interface IListingRepository : IGenericRepository<Listing>
{
    Task<Listing?> GetDetailAsync(Guid id);
    Task<List<Listing>> GetPagedAsync(int page, int pageSize);
    IQueryable<Listing> Query();
    Task<int> CountAsync();
    Task AddImagesAsync(List<ListingImage> images);
    Task<List<Listing>> SearchAsync(string keyword);
}