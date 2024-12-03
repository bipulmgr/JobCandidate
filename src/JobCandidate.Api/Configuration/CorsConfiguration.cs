namespace JobCandidate.Api.Configuration;

/// <summary>
/// Provides configuration for CORS.
/// </summary>
public static class CorsConfiguration
{
    /// <summary>
    /// Adds CORS configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        return services;
    }
}
