using System.Net.Http.Json;
using System.Text.Json;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Config;

namespace Tercuman.Mobile.Core.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorage _tokenStorage;

    public ApiService(HttpClient httpClient, ITokenStorage tokenStorage)
    {
        _httpClient = httpClient;
        _tokenStorage = tokenStorage;
        _httpClient.BaseAddress = new Uri(ApiSettings.ApiBaseUrl);
    }

    public async Task<TResponse> GetAsync<TResponse>(string endpoint)
    {
        await AddAuthHeader();
        var response = await _httpClient.GetAsync(endpoint);
        return await HandleResponse<TResponse>(response);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        await AddAuthHeader();
        var response = await _httpClient.PostAsJsonAsync(endpoint, data);
        return await HandleResponse<TResponse>(response);
    }

    private async Task AddAuthHeader()
    {
        var token = await _tokenStorage.GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<TResponse>();

        var errorContent = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Sorgu Hatası: {response.StatusCode} - {errorContent}");
    }
}