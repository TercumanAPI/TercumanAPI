using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tercuman.Infrastructure.Persistence;

public static class DbContextConfigurationExtensions
{
    public static DbContextOptionsBuilder ConfigureTercumanDatabase(
        this DbContextOptionsBuilder optionsBuilder,
        IConfiguration configuration,
        string connectionStringName = "DefaultConnection")
    {
        var connectionString = configuration.GetConnectionString(connectionStringName);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"Connection string '{connectionStringName}' is not configured.");
        }

        return optionsBuilder.ConfigureTercumanDatabase(connectionString);
    }

    public static DbContextOptionsBuilder ConfigureTercumanDatabase(
        this DbContextOptionsBuilder optionsBuilder,
        string connectionString)
    {
        if (IsSqliteConnectionString(connectionString))
        {
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder;
        }

        optionsBuilder.UseSqlServer(connectionString);
        return optionsBuilder;
    }

    public static bool IsSqliteConnectionString(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            return false;
        }

        return connectionString.Contains("Data Source=", StringComparison.OrdinalIgnoreCase)
            || connectionString.Contains("Filename=", StringComparison.OrdinalIgnoreCase)
            || connectionString.EndsWith(".db", StringComparison.OrdinalIgnoreCase)
            || connectionString.EndsWith(".sqlite", StringComparison.OrdinalIgnoreCase);
    }
}
