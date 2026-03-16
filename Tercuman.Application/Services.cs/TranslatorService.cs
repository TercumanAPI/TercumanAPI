using Tercuman.Application.DTOs.Translator;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Services;

public class TranslatorService : ITranslatorService
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IGenericRepository<Listing> _listingRepository;
    private readonly IGenericRepository<Favorite> _favoriteRepository;
    private readonly IUserRepository _userRepository;

    public TranslatorService(
        IGenericRepository<Message> messageRepository,
        IGenericRepository<Listing> listingRepository,
        IGenericRepository<Favorite> favoriteRepository,
        IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _listingRepository = listingRepository;
        _favoriteRepository = favoriteRepository;
        _userRepository = userRepository;
    }

    public async Task<TranslatorDashboardDto> GetDashboardAsync(Guid userId)
    {
        var listings = (await _listingRepository.FindAsync(x => x.UserId == userId && !x.IsDeleted)).ToList();
        var listingIds = listings.Select(x => x.Id).ToList();

        var totalMessages = (await _messageRepository.FindAsync(x => x.ReceiverId == userId)).Count();
        var unreadMessages = (await _messageRepository.FindAsync(x => x.ReceiverId == userId && !x.IsRead)).Count();
        var totalFavorites = (await _favoriteRepository.FindAsync(x => listingIds.Contains(x.ListingId))).Count();
        var totalViews = listings.Sum(x => x.ViewCount);

        return new TranslatorDashboardDto
        {
            TotalMessages = totalMessages,
            UnreadMessages = unreadMessages,
            TotalFavorites = totalFavorites,
            TotalViews = totalViews,
            TotalListings = listings.Count
        };
    }

    public async Task ToggleProfileStatusAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new Exception("Kullanıcı bulunamadı.");

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();
    }

    public async Task<List<string>> GetLanguagesAsync(Guid userId)
    {
        await Task.CompletedTask;
        return new List<string>();
    }
}
