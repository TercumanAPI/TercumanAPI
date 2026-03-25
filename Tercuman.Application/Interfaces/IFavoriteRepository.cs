using Tercuman.Application.DTOs.Favorite;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces
{
    public interface IFavoriteRepository
    {
        Task AddFavoriteAsync(Favorite favorite);
        Task RemoveFavoriteAsync(Favorite favorite);
        Task<bool> ExistsAsync(Guid userId, Guid listingId);
        Task<List<FavoriteItemDto>> GetUserFavoritesAsync(Guid userId);
        Task<Favorite?> GetFavoriteAsync(Guid userId, Guid listingId);
    }
}