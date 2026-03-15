using System.Net.Http.Json;
using Tercuman.Admin.Models;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.DTOs.User;

namespace Tercuman.Admin.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserProfileDto>> GetUsers()
        {
            return await _http.GetFromJsonAsync<List<UserProfileDto>>("api/users");
        }

        public async Task<List<ListingDto>> GetListings()
        {
            return await _http.GetFromJsonAsync<List<ListingDto>>("api/listings/admin");
        }

        public async Task DeleteListing(Guid id)
        {
            await _http.DeleteAsync($"api/listings/{id}");
        }

        public async Task<(List<ListingDto>, int)> GetListings(int page, int pageSize)
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<ListingDto>>(
                $"api/listings?page={page}&pageSize={pageSize}");

            return (result.data, result.totalCount);
        }

        public async Task<List<ListingListDto>> SearchListings(string keyword)
        {
            return await _http.GetFromJsonAsync<List<ListingListDto>>
            ($"api/listings/search?keyword={keyword}");
        }

        public async Task<int> GetUserCount()
        {
            return await _http.GetFromJsonAsync<int>("api/admin/users/count");
        }

        public async Task<int> GetListingCount()
        {
            return await _http.GetFromJsonAsync<int>("api/admin/listings/count");
        }

        public async Task<int> GetMessageCount()
        {
            return await _http.GetFromJsonAsync<int>("api/admin/messages/count");
        }

        public async Task<int> GetReviewCount()
        {
            return await _http.GetFromJsonAsync<int>("api/admin/reviews/count");
        }

        public async Task ToggleUser(Guid id)
        {
            await _http.PutAsync($"api/users/{id}/toggle-status", null);
        }

        public async Task DeleteUser(Guid id)
        {
            await _http.DeleteAsync($"api/users/{id}");
        }
    }
}