namespace JobCandidate.Core.Models.Entities;

/// <summary>
/// Represents a preferred call time interval.
/// </summary>
public class PreferredCallTime
{
    /// <summary>
    /// Gets or sets the start time of the time interval.
    /// </summary>
    public DateTime Start { get; set; }

    /// <summary>
    /// Gets or sets the end time of the time interval.
    /// </summary>
    public DateTime End { get; set; }
}
