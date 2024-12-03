using Serilog;

namespace JobCandidate.Api.Configuration;
/// <summary>
/// Provides logging configuration.
/// </summary>
public static class LoggingConfiguration
{
    /// <summary>
    /// Configures Serilog as the logging provider for the specified IHostBuilder.
    /// </summary>
    /// <param name="host">The IHostBuilder to configure.</param>
    /// <param name="configuration">The application's configuration.</param>
    /// <returns>The IHostBuilder with Serilog configured.</returns>
    public static IHostBuilder UseLoggingSetup(this IHostBuilder host, IConfiguration configuration)
    {
        host.UseSerilog(
            (_, _, lc) =>
            {
                lc.ReadFrom.Configuration(configuration);
            }
        );

        return host;
    }
}
