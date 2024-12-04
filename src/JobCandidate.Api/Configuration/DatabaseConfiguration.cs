using JobCandidate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Api.Configuration;

/// <summary>
/// Database configuration class
/// </summary>
public static class DatabaseConfiguration
{

    /// <summary>
    /// Adds database configuration to the service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">The configuration</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
        );

        return services;
    }

    /// <summary>
    /// Applies database migrations
    /// </summary>
    /// <param name="app">The application builder</param>
    public static void ApplyDatabaseMigrations(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            // Apply pending migrations
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(
                ex,
                "An error occurred while creating the database or applying migrations."
            );
            throw; // Rethrow the exception as this is a critical startup error
        }
    }
}
