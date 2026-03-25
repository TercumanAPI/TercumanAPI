using Refit;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;
using ContractApiResponse = Tercuman.Contracts.Responses.ApiResponse;

namespace Tercuman.Mobile.Services;

public interface IApiService
{
    [Post("/api/auth/login")]
    Task<ContractApiResponse<TokenDto>> Login([Body] LoginDto request);

    [Get("/api/listings")]
    Task<ContractApiResponse<PagedResultDto<ListingDto>>> GetListings();
}
