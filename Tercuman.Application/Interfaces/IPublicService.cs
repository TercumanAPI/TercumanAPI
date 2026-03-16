using Tercuman.Application.DTOs.Public;

namespace Tercuman.Application.Interfaces
{
    public interface IPublicService
    {
        Task<List<PublicTranslatorDto>> GetTranslatorsAsync();
        Task SendContactAsync(ContactFormDto dto);
    }
}