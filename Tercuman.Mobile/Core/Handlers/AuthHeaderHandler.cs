using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Handlers;

public class AuthHeaderHandler(ITokenStorage tokenStorage) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await tokenStorage.GetAccessTokenAsync();
        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
