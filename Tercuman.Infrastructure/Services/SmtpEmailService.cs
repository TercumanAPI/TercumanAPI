using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Tercuman.Application.Interfaces;

namespace Tercuman.Infrastructure.Services;

public class SmtpEmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public SmtpEmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        var host = _configuration["Smtp:Host"];
        var port = int.TryParse(_configuration["Smtp:Port"], out var parsedPort) ? parsedPort : 587;
        var username = _configuration["Smtp:Username"];
        var password = _configuration["Smtp:Password"];
        var from = _configuration["Smtp:From"] ?? username;

        if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(from))
            throw new InvalidOperationException("SMTP configuration is missing.");

        using var client = new SmtpClient(host, port)
        {
            EnableSsl = true,
            Credentials = !string.IsNullOrWhiteSpace(username)
                ? new NetworkCredential(username, password)
                : CredentialCache.DefaultNetworkCredentials
        };

        using var mail = new MailMessage(from, to, subject, body)
        {
            IsBodyHtml = false
        };

        await client.SendMailAsync(mail);
    }
}
