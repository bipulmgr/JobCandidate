using System.Reflection;
using JobCandidate.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobCandidate.Infrastructure.Data;
/// <summary>
/// Represents the database context for the application.
/// </summary>
public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    /// <param name="configuration">The configuration to be used by the DbContext.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Gets or sets the candidates DbSet.
    /// </summary>
    public DbSet<Candidate> Candidates { get; set; } = null!;

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types exposed in DbSet properties on your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
