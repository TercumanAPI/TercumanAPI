using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            return Ok(new
            {
                success = true,
                data = new
                {
                    totalMessages = result.TotalMessages,
                    unreadMessages = result.UnreadMessages,
                    totalFavorites = result.TotalFavorites,
                    totalViews = result.TotalViews,
                    totalListings = result.TotalListings
                },
                message = "Operation successful",
                errors = (object?)null
            });
        }

        [HttpPut("profile/toggle")]
        public async Task<IActionResult> ToggleProfile()
        {
            var userId = GetUserId();
            await _translatorService.ToggleProfileStatusAsync(userId);
            return Ok(new { message = "Durum güncellendi." });
        }

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var userId = GetUserId();
            var result = await _translatorService.GetLanguagesAsync(userId);
            return Ok(result);
        }
    }
}
