namespace Tercuman.Contracts.DTOs.Auth;

public class ExternalLoginDto
{
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string? ExternalId { get; set; }
    public required string Provider { get; set; }
}