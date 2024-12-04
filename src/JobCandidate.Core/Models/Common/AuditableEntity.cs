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
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The date and time when the entity was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The user who last updated the entity.
    /// </summary>
    public string? UpdatedBy { get; set; }
}
