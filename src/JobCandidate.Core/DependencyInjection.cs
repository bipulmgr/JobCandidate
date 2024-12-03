using Microsoft.Extensions.DependencyInjection;

namespace JobCandidate.Core;
/// <summary>
/// Provides extension methods for configuring Core services in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds Core services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <returns>The IServiceCollection so that additional calls can be chained.</returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services;
    }
}
