namespace Tercuman.Mobile.Core.Abstractions;

public interface IUserSession
{
    string? FullName { get; set; }
    string? Email { get; set; }
    Guid? UserId { get; set; }
    void Clear();
}
