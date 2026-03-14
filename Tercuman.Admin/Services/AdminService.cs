using System.Net.Http.Json;
using Tercuman.Admin.DTOS;

namespace Tercuman.Admin.Services;

public class AdminService
{
    private readonly HttpClient _http;

    public AdminService(HttpClient http)
    {
        _http = http;
    }

    public async Task<DashboardDto> GetDashboard()
    {
        var dashboard = await _http.GetFromJsonAsync<DashboardDto>("api/admin/dashboard");

        return dashboard ?? new DashboardDto();
    }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await _http.GetFromJsonAsync<List<UserDto>>("api/admin/users");

        return users ?? new List<UserDto>();
    }
}