using Tercuman.Application.DTOs.Translator;
using Tercuman.Application.Interfaces;

namespace Tercuman.Application.Services
{
    public class TranslatorService : ITranslatorService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IListingRepository _listingRepository;
        private readonly IUserRepository _userRepository;

        public TranslatorService(
            IMessageRepository messageRepository,
            IListingRepository listingRepository,
            IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _listingRepository = listingRepository;
            _userRepository = userRepository;
        }

        public async Task<TranslatorDashboardDto> GetDashboardAsync(Guid userId)
        {
            var allMessages = await _messageRepository.FindAsync(x => x.ReceiverId == userId);
            var unreadMessages = allMessages.Count(x => !x.IsRead);

            var listingQuery = _listingRepository.Query().Where(x => x.UserId == userId);

            return new TranslatorDashboardDto
            {
                TotalMessages = allMessages.Count(),
                UnreadMessages = unreadMessages,
                TotalFavorites = listingQuery.Sum(x => x.Favorites.Count),
                TotalViews = listingQuery.Sum(x => x.ViewCount)
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
}
