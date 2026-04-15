using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tercuman.API.Models;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly ILogger<FavoritesController> _logger;

        public FavoritesController(
            IFavoriteService favoriteService,
            ILogger<FavoritesController> logger)
        {
            _favoriteService = favoriteService;
            _logger = logger;
        }

        [HttpPost("{listingId:guid}")]
        public async Task<IActionResult> AddFavorite([FromRoute] Guid listingId)
        {
            try
            {
                var userId = GetUserId();
                await _favoriteService.AddFavoriteAsync(userId, listingId);

                return Ok(ApiResponse<object>.Ok(null, "İlan favorilere eklendi."));
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized AddFavorite attempt. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return Unauthorized(ApiResponse<object>.Fail(ex.Message));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Listing/User not found. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return NotFound(ApiResponse<object>.Fail(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Business rule error. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return StatusCode(500, ApiResponse<object>.Fail("Beklenmeyen bir hata oluştu."));
            }
        }

        [HttpDelete("{listingId:guid}")]
        public async Task<IActionResult> RemoveFavorite([FromRoute] Guid listingId)
        {
            try
            {
                var userId = GetUserId();
                await _favoriteService.RemoveFavoriteAsync(userId, listingId);

                return Ok(ApiResponse<object>.Ok(null, "İlan favorilerden çıkarıldı."));
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized RemoveFavorite attempt. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return Unauthorized(ApiResponse<object>.Fail(ex.Message));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<object>.Fail(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error. UserId: {UserId}, ListingId: {ListingId}",
                    GetSafeUserId(), listingId);

                return StatusCode(500, ApiResponse<object>.Fail("Beklenmeyen bir hata oluştu."));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            try
            {
                var userId = GetUserId();
                var favorites = await _favoriteService.GetUserFavoritesAsync(userId);

                return Ok(ApiResponse<object>.Ok(favorites));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ApiResponse<object>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while getting favorites. UserId: {UserId}",
                    GetSafeUserId());

                return StatusCode(500, ApiResponse<object>.Fail("Favoriler alınamadı."));
            }
        }

        [HttpGet("customer")]
        public Task<IActionResult> GetCustomerFavorites()
        {
            return GetMyFavorites();
        }

        private Guid GetUserId()
        {
            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                User.FindFirst("sub")?.Value ??
                User.FindFirst("userId")?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı ID.");
            }

            return userId;
        }

        private string GetSafeUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                   User.FindFirst("sub")?.Value ??
                   User.FindFirst("userId")?.Value ??
                   "unknown";
        }
    }
}