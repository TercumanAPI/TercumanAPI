using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services;

public class ApiService(HttpClient httpClient) : IApiService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public Task<TResponse?> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        => httpClient.GetFromJsonAsync<TResponse>(endpoint, JsonOptions, cancellationToken);

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync(endpoint, request, JsonOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PutAsJsonAsync(endpoint, request, JsonOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
    }

    public async Task<TResponse?> DeleteAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync(endpoint, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
    }
}
