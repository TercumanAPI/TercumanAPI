using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.DTOs.Review;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    /// <summary>
    /// Yeni bir yorum ve puan ekler (POST /api/reviews)
    /// </summary>
    [Authorize] // Sadece giriş yapmış kullanıcılar yorum yapabilir
    [HttpPost]
    public async Task<IActionResult> AddReview(CreateReviewDto dto)
    {
        // 1. ADIM: Token içindeki NameIdentifier (UserId) bilgisini güvenli bir şekilde alıyoruz
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("Kullanıcı bilgisi doğrulanamadı.");
        }

        try
        {
            // 2. ADIM: Servisi çağırıp işlemi yapıyoruz
            var result = await _reviewService.AddReviewAsync(userId, dto);
            return Ok(new { message = "Değerlendirmeniz başarıyla eklendi." });
        }
        catch (Exception ex)
        {
            // Servis katmanında fırlattığımız "Zaten yorum yaptınız" hatası buraya düşer
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Bir çevirmene ait tüm yorumları ve ortalama puanı getirir (GET /api/reviews/{translatorId})
    /// </summary>
    [HttpGet("{translatorId}")]
    public async Task<IActionResult> GetTranslatorReviews(Guid translatorId)
    {
        var result = await _reviewService.GetTranslatorReviewsAsync(translatorId);
        return Ok(result);
    }
}
