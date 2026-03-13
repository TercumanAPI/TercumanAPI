using Tercuman.Application.Interfaces;
using Tercuman.Application.DTOs.Review;
using Tercuman.Domin.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore; // Average ve diğer LINQ metotları için

namespace Tercuman.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IGenericRepository<Review> _repository;

    public ReviewService(IGenericRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddReviewAsync(string userId, CreateReviewDto dto)
    {
        // 3. MADDE KONTROLÜ: Aynı kullanıcı bu ilan için daha önce yorum yapmış mı?
        // userId string olarak karşılaştırılıyor.
        var existing = await _repository.FindAsync(r => r.UserId == userId && r.ListingId == dto.ListingId);

        if (existing.Any())
        {
            throw new Exception("Bu ilan için zaten bir değerlendirme yaptınız.");
        }

        var review = new Review
        {
            // BaseEntity'den gelen Id otomatik Guid olarak atanır.
            UserId = userId,
            TranslatorId = dto.TranslatorId.ToString(),
            ListingId = dto.ListingId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedDate = DateTime.UtcNow
        };

        await _repository.AddAsync(review);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<object> GetTranslatorReviewsAsync(Guid translatorId)
    {
        // Guid tipini string'e çevirip öyle aratıyoruz (Entity'deki tip ile uyum için)
        string tid = translatorId.ToString();
        var reviews = await _repository.FindAsync(r => r.TranslatorId == tid);

        // Veriyi listeye çeviriyoruz ki Count ve Average işlemleri hata vermesin
        var reviewList = reviews.ToList();

        // 4. VE 5. MADDE: İstatistiklerin hesaplanması
        return new
        {
            // AverageRating hesaplanırken null check yapılıyor
            AverageRating = reviewList.Any() ? reviewList.Average(r => (double)r.Rating) : 0,
            TotalReviews = reviewList.Count, // .Count() metot değil, özelliktir.
            Reviews = reviewList.Select(r => new ReviewDto
            {
                Id = r.Id,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedDate = r.CreatedDate
            }).ToList()
        };
    }
}