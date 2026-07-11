using Tercuman.Application.Interfaces;
using Tercuman.Contracts.DTOs.Translator;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Services;

public class TranslatorService : ITranslatorService
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IGenericRepository<Listing> _listingRepository;
    private readonly IGenericRepository<Favorite> _favoriteRepository;
    private readonly IGenericRepository<Language> _languageRepository;
    private readonly IUserRepository _userRepository;

    public TranslatorService(
        IGenericRepository<Message> messageRepository,
        IGenericRepository<Listing> listingRepository,
        IGenericRepository<Favorite> favoriteRepository,
        IGenericRepository<Language> languageRepository,
        IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _listingRepository = listingRepository;
        _favoriteRepository = favoriteRepository;
        _languageRepository = languageRepository;
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
            TotalViews = totalViews
        };
    }

    public async Task ToggleProfileStatusAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new Exception("Kullanıcı bulunamadı.");

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();
    }

    public async Task<List<LanguageDto>> GetLanguagesAsync(Guid userId)
    {
        var listings = (await _listingRepository.FindAsync(x => x.UserId == userId && !x.IsDeleted)).ToList();
        if (listings.Count == 0)
        {
            return new List<LanguageDto>();
        }

        var languageIds = listings
            .SelectMany(x => new[] { x.SourceLanguageId, x.TargetLanguageId })
            .Distinct()
            .ToList();

        var languages = (await _languageRepository.FindAsync(x => languageIds.Contains(x.Id)))
            .OrderBy(x => x.Name)
            .ToList();

        return languages.Select(x => new LanguageDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}
