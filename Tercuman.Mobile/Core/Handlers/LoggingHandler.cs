namespace Tercuman.Mobile.Core.Handlers;

public class LoggingHandler(ILogger<LoggingHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("HTTP {Method} {Uri}", request.Method, request.RequestUri);
        var response = await base.SendAsync(request, cancellationToken);
        logger.LogInformation("HTTP {StatusCode}", response.StatusCode);
        return response;
    }
}
