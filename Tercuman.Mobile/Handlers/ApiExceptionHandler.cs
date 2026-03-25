namespace Tercuman.Mobile.Handlers;

public class ApiExceptionHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception("API bağlantı hatası: " + ex.Message, ex);
        }
    }
}
