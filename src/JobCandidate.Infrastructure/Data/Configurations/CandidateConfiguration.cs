using JobCandidate.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCandidate.Infrastructure.Data.Configurations;

/// <summary>
/// Represents a configuration for the candidate entity.
/// </summary>
public class CandidateConfiguration : AuditableEntityConfiguration<Candidate>
{
    /// <summary>
    /// Configures the candidate entity.
    /// </summary>
    /// <param name="builder">The builder to configure the entity.</param>
    public override void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("Candidates");

        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(15);

        builder.OwnsOne(
            x => x.PreferredCallTime,
            x =>
            {
                x.ToJson();
            });

        builder.Property(c => c.LinkedInUrl)
            .HasMaxLength(200);

        builder.Property(c => c.GitHubUrl)
            .HasMaxLength(200);

        builder.Property(c => c.Comments)
            .HasMaxLength(4000)
            .IsRequired();
    }
}
