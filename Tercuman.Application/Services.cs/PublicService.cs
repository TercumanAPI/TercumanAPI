using Microsoft.EntityFrameworkCore;
using Tercuman.Application.DTOs.Public;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Services
{
    public class PublicService : IPublicService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactMessageRepository _contactMessageRepository;

        public PublicService(
            IUserRepository userRepository,
            IContactMessageRepository contactMessageRepository)
        {
            _userRepository = userRepository;
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<List<PublicTranslatorDto>> GetTranslatorsAsync()
        {
            var translators = await _userRepository.Query()
                .Where(x => x.Role == "Translator")
                .Select(x => new PublicTranslatorDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    City = x.City,
                    Bio = x.Bio,
                    ProfileImage = x.ProfileImageUrl,
                    IsAvailable = x.IsActive
                })
                .ToListAsync();

            return translators;
        }

        public async Task SendContactAsync(ContactFormDto dto)
        {
            var message = new ContactMessage
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                Subject = dto.Subject,
                Message = dto.Message,
                CreatedAt = DateTime.UtcNow
            };

            await _contactMessageRepository.AddAsync(message);
            await _contactMessageRepository.SaveChangesAsync();
        }
    }
}