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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddReview(CreateReviewDto dto)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized("Kullanıcı bilgisi doğrulanamadı.");
        }

        Guid userId = Guid.Parse(userIdClaim);

        try
        {
            var result = await _reviewService.AddReviewAsync(userId, dto);

            return Ok(new { message = "Değerlendirmeniz başarıyla eklendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{translatorId}")]
    public async Task<IActionResult> GetTranslatorReviews(Guid translatorId)
    {
        var result = await _reviewService.GetTranslatorReviewsAsync(translatorId);
        return Ok(result);
    }
}