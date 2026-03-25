using Refit;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Contracts.Responses;

namespace Tercuman.Mobile.Services;

public interface IApiService
{
    [Post("/api/auth/login")]
    Task<Contracts.Responses.ApiResponse<TokenDto>> Login([Body] LoginDto request);

    [Get("/api/listings")]
    Task<Contracts.Responses.ApiResponse<PagedResultDto<ListingDto>>> GetListings();
}