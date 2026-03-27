using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services;

public class UserSession : IUserSession
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Guid? UserId { get; set; }
    public void Clear()
    {
        FullName = null;
        Email = null;
        UserId = null;
    }
}
