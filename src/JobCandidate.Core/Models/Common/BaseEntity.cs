namespace JobCandidate.Core.Models.Common;

/// <summary>
/// Represents a base entity.
/// </summary>
public abstract class BaseEntity
{

    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    public string Id { get; set; } = null!;
}
