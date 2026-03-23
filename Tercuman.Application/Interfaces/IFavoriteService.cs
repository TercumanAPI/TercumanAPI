using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces;

public interface IFavoriteService
{
    Task AddFavoriteAsync(Guid userId, Guid listingId);
    Task RemoveFavoriteAsync(Guid userId, Guid listingId);
    Task<IEnumerable<Favorite>> GetUserFavoritesAsync(Guid userId);
}
