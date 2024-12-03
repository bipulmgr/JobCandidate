using JobCandidate.Api.Configuration;
using JobCandidate.Api.Middleware;
using JobCandidate.Core;
using JobCandidate.Infrastructure;
using JobCandidate.Shared;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();


// Add Application Insights
builder.Services.AddApplicationInsightsTelemetry();

// Register services
builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSharedServices();

// Add database configuration
builder.Services.AddDatabaseConfiguration(builder.Configuration);

var app = builder.Build();

// Apply migrations and ensure database creation
DatabaseConfiguration.ApplyDatabaseMigrations(app);

app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });

app.UseCors();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

await app.RunAsync();

// This line should be at the end of the file
public partial class Program { }
