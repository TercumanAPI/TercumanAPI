using System.Threading.Tasks;
using Tercuman.Application.DTOs.Auth;

namespace Tercuman.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);

        // DİKKAT: string yazan yerleri TokenDto yaptık!
        Task<TokenDto> LoginAsync(LoginDto dto);
        Task<TokenDto> RefreshTokenAsync(string refreshToken);

        Task ForgotPasswordAsync(string email);
    }
}