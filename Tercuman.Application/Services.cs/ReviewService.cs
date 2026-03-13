using Tercuman.Application.Interfaces;
using Tercuman.Application.DTOs.Review;
using Tercuman.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tercuman.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IGenericRepository<Review> _repository;

    public ReviewService(IGenericRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddReviewAsync(Guid userId, CreateReviewDto dto)
    {
        // Aynı kullanıcı aynı ilana yorum yapmış mı
        var existing = await _repository.FindAsync(
            r => r.UserId == userId && r.ListingId == dto.ListingId
        );

        if (existing.Any())
        {
            throw new Exception("Bu ilan için zaten değerlendirme yaptınız.");
        }

        var review = new Review
        {
            UserId = userId,
            TranslatorId = dto.TranslatorId,
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
        var reviews = await _repository.FindAsync(
            r => r.TranslatorId == translatorId
        );

        var reviewList = reviews.ToList();

        return new
        {
            AverageRating = reviewList.Any()
                ? reviewList.Average(r => (double)r.Rating)
                : 0,

            TotalReviews = reviewList.Count,

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