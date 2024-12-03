namespace JobCandidate.Core.Models.Common;

/// <summary>
/// Represents an auditable entity.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The user who created the entity.
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// The date and time when the entity was last modified.
    /// </summary>
    public DateTime? LastModifiedAt { get; set; }

    /// <summary>
    /// The user who last modified the entity.
    /// </summary>
    public string LastModifiedBy { get; set; } = string.Empty;
}
