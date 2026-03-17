using Refit;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.Service;

public interface IApiService
{
    [Post("/api/auth/login")]
    Task<ApiResponse<LoginResponseDto>> Login(LoginDto dto);

    [Get("/api/listings")]
    Task<ApiResponse<List<ListingDto>>> GetListings();
}