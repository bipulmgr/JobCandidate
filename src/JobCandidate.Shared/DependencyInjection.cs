using Microsoft.Extensions.DependencyInjection;

namespace JobCandidate.Shared;
public static class DependencyInjection
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        // Add shared services here
        return services;
    }
}
