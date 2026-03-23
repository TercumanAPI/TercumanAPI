using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Tercuman.Domain.Entities;

namespace Tercuman.Infrastructure.Persistence;

public static class AdminSeedExtensions
{
    public static async Task SeedInitialAdminAsync(this IServiceProvider services, IConfiguration configuration)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (await db.Users.AnyAsync(x => x.Role == "Admin"))
        {
            return;
        }

        var adminSection = configuration.GetSection("AdminSeed");
        var email = adminSection["Email"] ?? "admin@tercuman.com";
        var password = adminSection["Password"] ?? "Admin123!";
        var fullName = adminSection["FullName"] ?? "System Admin";

        var existingUser = await db.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (existingUser == null)
        {
            existingUser = new User
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "Admin",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            await db.Users.AddAsync(existingUser);
        }
        else
        {
            existingUser.Role = "Admin";
            existingUser.IsActive = true;
            existingUser.UpdatedDate = DateTime.UtcNow;
        }

        await db.SaveChangesAsync();
    }
}
