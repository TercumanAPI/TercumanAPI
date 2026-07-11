using Tercuman.Application.DTOs.Favorite;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IListingRepository _listingRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository, IListingRepository listingRepository)
        {
            _favoriteRepository = favoriteRepository;
            _listingRepository = listingRepository;
        }

        public async Task AddFavoriteAsync(Guid userId, Guid listingId)
        {
            var listing = await _listingRepository.GetByIdAsync(listingId);
            if (listing == null)
            {
                throw new Exception("Listing not found.");
            }

            var exists = await _favoriteRepository.ExistsAsync(userId, listingId);
            if (exists)
            {
                throw new Exception("This listing is already in favorites.");
            }

            var favorite = new Favorite
            {
                UserId = userId,
                ListingId = listingId,
                CreatedDate = DateTime.UtcNow
            };

            await _favoriteRepository.AddFavoriteAsync(favorite);
        }

        public async Task RemoveFavoriteAsync(Guid userId, Guid listingId)
        {
            var favorite = await _favoriteRepository.GetFavoriteAsync(userId, listingId);
            if (favorite == null)
            {
                throw new Exception("Favorite not found.");
            }

            await _favoriteRepository.RemoveFavoriteAsync(favorite);
        }

        public async Task<List<FavoriteItemDto>> GetUserFavoritesAsync(Guid userId)
        {
            return await _favoriteRepository.GetUserFavoritesAsync(userId);
        }
    }
}