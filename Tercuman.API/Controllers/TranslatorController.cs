using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Tercuman.Infrastructure.Persistence;

[Authorize(Roles = "Translator")]
[ApiController]
[Route("api/translator")]
public class TranslatorController : ControllerBase
{
    private readonly AppDbContext _context;
    public TranslatorController(AppDbContext context) => _context = context;

    [HttpGet("dashboard")]
    public IActionResult GetDashboardStats()
    {
        // Reviews, Conversations tablolarından istatistik çekilir
        return Ok(new { totalReviews = 0, activeJobs = 0 });
    }

    [HttpPut("profile/toggle")]
    public IActionResult ToggleStatus()
    {
        // Profil aktif/pasif çekme mantığı
        return Ok();
    }
}
=======
using System.Security.Claims;
using Tercuman.API.Models;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslatorService _translatorService;

        public TranslatorController(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        private Guid GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userId!);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var userId = GetUserId();
            var result = await _translatorService.GetDashboardAsync(userId);
            return Ok(ApiResponse<object>.Ok(new
            {
                totalMessages = result.TotalMessages,
                unreadMessages = result.UnreadMessages,
                totalFavorites = result.TotalFavorites,
                totalViews = result.TotalViews
            }));
        }

        [HttpPut("profile/toggle")]
        public async Task<IActionResult> ToggleProfile()
        {
            var userId = GetUserId();
            await _translatorService.ToggleProfileStatusAsync(userId);
            return Ok(ApiResponse<object>.Ok(null, "Durum güncellendi."));
        }

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var userId = GetUserId();
            var result = await _translatorService.GetLanguagesAsync(userId);
            return Ok(ApiResponse<object>.Ok(result));
        }
    }
}
>>>>>>> 0426f3014207cc9f149fd2f8b942c2cdddd16ba2
