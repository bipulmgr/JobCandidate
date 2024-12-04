using JobCandidate.Core.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCandidate.Infrastructure.Data.Configurations;
/// <summary>
/// Represents the configuration for base entities.
/// </summary>
/// <typeparam name="T">The type of the base entity.</typeparam>
public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
{
    /// <summary>
    /// Configures the entity properties for base entities.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(12);
    }
}
