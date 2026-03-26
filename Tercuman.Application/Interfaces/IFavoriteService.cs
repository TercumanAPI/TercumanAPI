using Tercuman.Application.DTOs.Favorite;

namespace Tercuman.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task AddFavoriteAsync(Guid userId, Guid listingId);
        Task RemoveFavoriteAsync(Guid userId, Guid listingId);
        Task<List<FavoriteItemDto>> GetUserFavoritesAsync(Guid userId);
    }
}