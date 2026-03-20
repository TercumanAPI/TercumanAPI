using Tercuman.Contracts.DTOs.Translator;

namespace Tercuman.Application.Interfaces
{
    public interface ITranslatorService
    {
        Task<TranslatorDashboardDto> GetDashboardAsync(Guid userId);
        Task ToggleProfileStatusAsync(Guid userId);
        Task<List<string>> GetLanguagesAsync(Guid userId);
    }
}