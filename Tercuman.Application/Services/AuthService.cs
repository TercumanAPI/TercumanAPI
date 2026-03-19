using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tercuman.Application.Interfaces;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Domain.Entities;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, IEmailService emailService)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _emailService = emailService;
    }

    // REGISTER
    public async Task RegisterAsync(RegisterDto dto)
    {
        try
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new Exception("Bu email zaten kayıtlı");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedDate = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Register failed: " + ex.Message);
        }
    }

    // LOGIN
    public async Task<TokenDto> LoginAsync(LoginDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email boş olamaz");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Şifre boş olamaz");

            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
                throw new Exception("User not found");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid password");

            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
            );

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(jwtSettings["ExpiryMinutes"]!)
                ),
                signingCredentials:
                    new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = Convert.ToBase64String(
                System.Security.Cryptography.RandomNumberGenerator.GetBytes(64)
            );

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userRepository.SaveChangesAsync();

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Login failed: " + ex.Message);
        }
    }

    // REFRESH TOKEN
    public async Task<TokenDto> RefreshTokenAsync(string refreshToken)
    {
        try
        {
            await Task.CompletedTask;

            return new TokenDto
            {
                AccessToken = GenerateJwtToken(),
                RefreshToken = refreshToken
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Refresh token failed: " + ex.Message);
        }
    }

    // JWT üretme
    private string GenerateJwtToken()
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
        );

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            expires: DateTime.UtcNow.AddMinutes(
                int.Parse(jwtSettings["ExpiryMinutes"]!)
            ),
            signingCredentials:
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // FORGOT PASSWORD
    public async Task ForgotPasswordAsync(string email)
    {
        try
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                throw new Exception("User not found");

            await _emailService.SendAsync(
                user.Email,
                "Tercuman - Password Reset",
                "Şifre sıfırlama talebiniz alınmıştır. Lütfen panelden şifre yenileme adımlarını takip edin."
            );
        }
        catch (Exception ex)
        {
            throw new Exception("Forgot password failed: " + ex.Message);
        }
    }
}