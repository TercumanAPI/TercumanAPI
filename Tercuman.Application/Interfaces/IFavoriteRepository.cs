using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tercuman.Domin.Entities; // Entity katmanının doğru namespace'i

namespace Tercuman.Application.Interfaces
{
    public interface IFavoriteRepository
    {
        Task AddFavoriteAsync(Favorite favorite);
        Task RemoveFavoriteAsync(Favorite favorite);
        Task<bool> ExistsAsync(Guid userId, Guid listingId);
        Task<IEnumerable<Favorite>> GetUserFavoritesAsync(Guid userId);
        Task<Favorite?> GetFavoriteAsync(Guid userId, Guid listingId);
    }
}
