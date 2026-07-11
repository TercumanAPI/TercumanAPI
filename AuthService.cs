using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services
{
    public class AuthService : IAuthService
    {
        public Task RegisterAsync(RegisterDto dto)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public Task<TokenDto> LoginAsync(LoginDto dto)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public Task<TokenDto> RefreshTokenAsync(string refreshToken)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public Task ForgotPasswordAsync(string email)
        {
            // Implementation here
            throw new NotImplementedException();
        }
    }
}
