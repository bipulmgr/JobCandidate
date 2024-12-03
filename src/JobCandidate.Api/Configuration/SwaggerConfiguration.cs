using Microsoft.OpenApi.Models;

namespace JobCandidate.Api.Configuration;
/// <summary>
/// Provides Swagger configuration.
/// </summary>
public static class SwaggerConfiguration
{
    /// <summary>
    /// Adds Swagger configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo { Title = "Enterprise API Starter", Version = "v1" }
            );
            c.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                }
            );
            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        new string[] { }
                    },
                }
            );
        });

        return services;
    }

    /// <summary>
    /// Uses Swagger configuration.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseSwaggerConfiguration(
        this IApplicationBuilder app,
        IWebHostEnvironment env
    )
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enterprise API Starter v1");
                c.RoutePrefix = string.Empty;
            });
        }

        return app;
    }
}
