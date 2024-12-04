using JobCandidate.Core.Models.Entities;

namespace JobCandidate.Core.Models.Response;

/// <summary>
/// Represents a response model for a candidate.
/// </summary>
public class CandidateResponseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the candidate.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the first name of the candidate.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the candidate.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email of the candidate.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phone number of the candidate.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the preferred call time of the candidate.
    /// </summary>
    public PreferredCallTime? PreferredCallTime { get; set; }

    /// <summary>
    /// Gets or sets the LinkedIn URL of the candidate.
    /// </summary>
    public string? LinkedInUrl { get; set; }

    /// <summary>
    /// Gets or sets the GitHub URL of the candidate.
    /// </summary>
    public string? GitHubUrl { get; set; }

    /// <summary>
    /// Gets or sets the comments of the candidate.
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the candidate was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the candidate was last modified.
    /// </summary>
    public DateTime? ModifiedAt { get; set; }
}
