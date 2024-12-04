
using JobCandidate.Core.Models.Entities;

namespace JobCandidate.Core.Models.Request;

/// <summary>
/// Represents a request model for a candidate.
/// </summary>
public class CandidateRequestModel
{
    /// <summary>
    /// Gets or sets the first name of the candidate.
    /// </summary>
    public string FirstName { get; init; } = null!;

    /// <summary>
    /// Gets or sets the last name of the candidate.
    /// </summary>
    public string LastName { get; init; } = null!;

    /// <summary>
    /// Gets or sets the email of the candidate.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Gets or sets the phone number of the candidate.
    /// </summary>
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Gets or sets the preferred call start time of the candidate.
    /// </summary>
    public PreferredCallTime? PreferredCallTime { get; init; }

    /// <summary>
    /// Gets or sets the LinkedIn URL of the candidate.
    /// </summary>
    public string? LinkedInUrl { get; init; }

    /// <summary>
    /// Gets or sets the GitHub URL of the candidate.
    /// </summary>
    public string? GitHubUrl { get; init; }

    /// <summary>
    /// Gets or sets the comments of the candidate.
    /// </summary>
    public string Comments { get; init; } = null!;
}
