using Tercuman.Application.DTOs.Review;

namespace Tercuman.Application.Interfaces;

public interface IReviewService
{
    // Yeni yorum ekleme (userId token'dan gelecek)
    Task<bool> AddReviewAsync(Guid userId, CreateReviewDto dto);

    // Çevirmen istatistiklerini ve yorumlarını getirme
    Task<object> GetTranslatorReviewsAsync(Guid translatorId);
}