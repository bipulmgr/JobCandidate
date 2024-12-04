using JobCandidate.Core.Models.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCandidate.Infrastructure.Data.Configurations;
/// <summary>
/// Represents the configuration for auditable entities.
/// </summary>
/// <typeparam name="T">The type of the auditable entity.</typeparam>
public abstract class AuditableEntityConfiguration<T> : BaseEntityConfiguration<T>
    where T : AuditableEntity
{
    /// <summary>
    /// Configures the entity properties for auditable entities.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.CreatedBy).HasMaxLength(12);
        builder.Property(e => e.UpdatedAt);
        builder.Property(e => e.UpdatedBy).HasMaxLength(12);
    }
}
