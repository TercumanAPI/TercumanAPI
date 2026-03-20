using System.Net.Http.Headers;
using Tercuman.Mobile.Storage;

namespace Tercuman.Mobile.Handlers;

public class AuthHeaderHandler : DelegatingHandler
{
    // TokenStorageService, token'ı güvenli bir şekilde saklamak ve almak için kullanılan bir servis.

    private readonly TokenStorageService _tokenService;

    // Bu handler, her HTTP isteği gönderilmeden önce çalışır ve token'ı alarak Authorization header'ına ekler.
    public AuthHeaderHandler(TokenStorageService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetTokenAsync();

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}