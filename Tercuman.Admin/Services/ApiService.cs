using System.Net.Http.Json;
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
    }

}
