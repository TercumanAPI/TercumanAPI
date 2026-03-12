using Tercuman.Domin.Enums;

public class UserProfileDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = "";

    public string Email { get; set; } = "";

    public string? Bio { get; set; }

    public string? PhoneNumber { get; set; }

    public string? City { get; set; }

    public string? ProfileImageUrl { get; set; }

    public Gender Gender { get; set; }

    public bool IsActive { get; set; }
}