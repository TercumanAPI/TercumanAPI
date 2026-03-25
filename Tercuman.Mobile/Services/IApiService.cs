using Refit;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.Services;

public interface IApiService
{
    [Post("/api/auth/login")]
    Task<ApiResponse<TokenDto>> Login([Body] LoginDto request);

    [Get("/api/listings")]
    Task<ApiResponse<PagedResultDto<ListingDto>>> GetListings();
}
