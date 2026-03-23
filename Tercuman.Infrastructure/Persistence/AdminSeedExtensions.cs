using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tercuman.Domain.Entities;

namespace Tercuman.Infrastructure.Persistence;

public static class AdminSeedExtensions
{
    public static async Task SeedInitialAdminAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        const string adminEmail = "musaab1031997@gmail.com";
        const string adminPassword = "Tercuman1997";
        const string adminFullName = "Musab";

        var user = await db.Users.FirstOrDefaultAsync(x => x.Email == adminEmail);

        if (user == null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                Email = adminEmail,
                FullName = adminFullName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword),
                Role = "Admin",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            await db.Users.AddAsync(user);
        }
        else
        {
            user.Email = adminEmail;
            user.FullName = adminFullName;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword);
            user.Role = "Admin";
            user.IsActive = true;
            user.UpdatedDate = DateTime.UtcNow;
        }

        var otherUsers = await db.Users
            .Where(x => x.Email != adminEmail && x.Role == "Admin")
            .ToListAsync();

        foreach (var otherUser in otherUsers)
        {
            otherUser.Role = "Customer";
            otherUser.UpdatedDate = DateTime.UtcNow;
        }

        await db.SaveChangesAsync();
    }
}
