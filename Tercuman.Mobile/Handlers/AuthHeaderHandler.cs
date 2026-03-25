using System.Net;
using System.Net.Http.Headers;
using Tercuman.Mobile.Storage;

namespace Tercuman.Mobile.Handlers;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly TokenStorageService _tokenService;

    public AuthHeaderHandler(TokenStorageService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            var token = await _tokenService.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            // 🔥 request iptal edildiğinde uygulama crash olmasın
            return new HttpResponseMessage(HttpStatusCode.RequestTimeout)
            {
                RequestMessage = request
            };
        }
    }
}