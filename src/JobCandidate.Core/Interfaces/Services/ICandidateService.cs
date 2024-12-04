using JobCandidate.Core.Models.Request;
using JobCandidate.Core.Models.Response;

namespace JobCandidate.Core.Interfaces.Services;

/// <summary>
/// Represents a service for candidates.
/// </summary>
public interface ICandidateService
{
    /// <summary>
    /// Creates or updates a candidate based on the email address.
    /// </summary>
    /// <param name="requestModel">The request model containing candidate information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response model containing the created or updated candidate.</returns>
    Task<CandidateResponseModel> CreateOrUpdateCandidateAsync(CandidateRequestModel requestModel, CancellationToken cancellationToken);
}
