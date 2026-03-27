namespace Tercuman.Mobile.Core.Handlers;

public class RetryHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        const int maxRetry = 2;
        for (var i = 0; i <= maxRetry; i++)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if ((int)response.StatusCode < 500 || i == maxRetry)
            {
                return response;
            }
        }

        throw new HttpRequestException("Retry failed.");
    }
}
