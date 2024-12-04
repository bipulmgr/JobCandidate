using JobCandidate.Core.Models.Common;

namespace JobCandidate.Core.Models.Entities;

/// <summary>
/// Represents a job candidate.
/// </summary>s
public class Candidate : AuditableEntity
{
    /// <summary>
    /// Gets or sets the first name of the job candidate.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the job candidate.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email of the job candidate.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the job candidate.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the preferred call time interval of the job candidate.
    /// Stored as JSON string containing start and end time.
    /// </summary>
    public PreferredCallTime? PreferredCallTime { get; set; }

    /// <summary>
    /// Gets or sets the LinkedIn URL of the job candidate.
    /// </summary>
    public string? LinkedInUrl { get; set; }

    /// <summary>
    /// Gets or sets the GitHub URL of the job candidate.
    /// </summary>
    public string? GitHubUrl { get; set; }

    /// <summary>
    /// Gets or sets the comments of the job candidate.
    /// </summary>
    public required string Comments { get; set; }
}
