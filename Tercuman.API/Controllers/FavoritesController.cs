using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.API.Models;
using Tercuman.Application.Services;

namespace Tercuman.API.Controllers
{
    [Authorize] // Kullanıcı login olmak zorunda
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;

        public FavoritesController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost("{listingId}")]
        public async Task<IActionResult> AddFavorite(Guid listingId)
        {
            try
            {
                var userId = GetUserId();
                await _favoriteService.AddFavoriteAsync(userId, listingId);
                return Ok(ApiResponse<object>.Ok(null, "İlan favorilere eklendi."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpDelete("{listingId}")]
        public async Task<IActionResult> RemoveFavorite(Guid listingId)
        {
            try
            {
                var userId = GetUserId();
                await _favoriteService.RemoveFavoriteAsync(userId, listingId);
                return Ok(ApiResponse<object>.Ok(null, "İlan favorilerden çıkarıldı."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = GetUserId();
            var favorites = await _favoriteService.GetUserFavoritesAsync(userId);
            return Ok(ApiResponse<object>.Ok(favorites));
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerFavorites()
        {
            var userId = GetUserId();
            var favorites = await _favoriteService.GetUserFavoritesAsync(userId);
            return Ok(ApiResponse<object>.Ok(favorites));
        }

        // Token'dan UserId'yi güvenli şekilde çıkaran yardımcı metot
        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                throw new UnauthorizedAccessException("Geçersiz veya eksik kullanıcı kimliği.");
            }
            return userId;
        }
    }
}
