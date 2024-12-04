using JobCandidate.Core.Interfaces.Repositories;
using JobCandidate.Core.Interfaces.Services;
using JobCandidate.Core.Models.Entities;
using JobCandidate.Core.Models.Request;
using JobCandidate.Core.Models.Response;
using JobCandidate.Shared.CommonHelpers;
using Mapster;
using Microsoft.Extensions.Logging;

namespace JobCandidate.Core.Services;

/// <summary>
/// Represents a service for candidates.
/// </summary>
public class CandidateService : ICandidateService
{
    private readonly IRepository<Candidate> _candidateRepository;
    private readonly ILogger<CandidateService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CandidateService"/> class.
    /// </summary>
    /// <param name="candidateRepository">The candidate repository.</param>
    /// <param name="logger">The logger instance.</param>
    public CandidateService(IRepository<Candidate> candidateRepository, ILogger<CandidateService> logger)
    {
        _candidateRepository = candidateRepository;
        _logger = logger;
    }

    /// <summary>
    /// Creates or updates a candidate based on the email address.
    /// </summary>
    /// <param name="requestModel">The request model containing candidate information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response model containing the created or updated candidate.</returns>
    public async Task<CandidateResponseModel> CreateOrUpdateCandidateAsync(
        CandidateRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        try
        {
            var candidate = await _candidateRepository.GetFirstOrDefaultAsync(
                c => c.Email.ToLower() == requestModel.Email.ToLower());

            if (candidate == null)
            {
                var newCandidate = requestModel.Adapt<Candidate>();
                newCandidate.Id = CustomNewId.GenerateShortId();
                newCandidate.CreatedAt = DateTime.UtcNow;
                candidate = await _candidateRepository.AddAsync(newCandidate);
            }
            else
            {
                candidate.FirstName = requestModel.FirstName;
                candidate.LastName = requestModel.LastName;
                candidate.PhoneNumber = requestModel.PhoneNumber;
                candidate.LinkedInUrl = requestModel.LinkedInUrl;
                candidate.GitHubUrl = requestModel.GitHubUrl;
                candidate.Comments = requestModel.Comments;
                candidate.PreferredCallTime = requestModel.PreferredCallTime.Adapt<PreferredCallTime>();
                candidate.UpdatedAt = DateTime.UtcNow;
                await _candidateRepository.UpdateAsync(candidate);
            }

            return candidate.Adapt<CandidateResponseModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating or updating candidate: {Message}", ex.Message);
            throw;
        }
    }
}
