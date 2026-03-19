using Refit;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.Services;

public interface IApiService
{
    [Post("/api/auth/login")]
    Task<ApiResponse<LoginResponseDto>> Login([Body] LoginDto dto);

    [Get("/api/listings")]
    Task<ApiResponse<List<ListingDto>>> GetListings();
}