using FluentValidation;
using JobCandidate.Core.Interfaces.Services;
using JobCandidate.Core.Models.Request;
using JobCandidate.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidate.Api.Controllers.V1;

/// <summary>
/// Represents a controller for candidates.
/// </summary>
public class CandidateController : BaseController
{
    private readonly ICandidateService _candidateService;
    private readonly IValidator<CandidateRequestModel> _validator;

    /// <summary>
    /// Candidate controller constructor
    /// </summary>
    /// <param name="candidateService">The candidate service</param>
    /// <param name="validator">The validator</param>
    public CandidateController(
        ICandidateService candidateService,
        IValidator<CandidateRequestModel> validator)
    {
        _candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    /// <summary>
    /// Creates or updates a candidate based on the email address.
    /// </summary>
    /// <param name="request">The candidate information.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created or updated candidate.</returns>
    /// <response code="200">Returns the created or updated candidate.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="500">If there was an internal server error.</response>
    [HttpPut]
    [ProducesResponseType(typeof(CandidateResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CandidateResponseModel>> UpsertCandidate(
        [FromBody] CandidateRequestModel request,
        CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var result = await _candidateService.CreateOrUpdateCandidateAsync(request, cancellationToken);
        return Ok(result);
    }
}
