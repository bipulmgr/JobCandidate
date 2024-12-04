using FluentValidation;
using FluentValidation.Results;
using JobCandidate.Api.Controllers.V1;
using JobCandidate.Core.Interfaces.Services;
using JobCandidate.Core.Models.Entities;
using JobCandidate.Core.Models.Request;
using JobCandidate.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JobCandidate.Api.Test;

/// <summary>
/// Candidate controller test class
/// </summary>
public class CandidateControllerTest
{
    private readonly Mock<ICandidateService> _mockCandidateService;
    private readonly Mock<IValidator<CandidateRequestModel>> _mockValidator;
    private readonly CandidateController _controller;

    /// <summary>
    /// Candidate controller test constructor
    /// </summary>
    public CandidateControllerTest()
    {
        _mockCandidateService = new Mock<ICandidateService>();
        _mockValidator = new Mock<IValidator<CandidateRequestModel>>();
        _controller = new CandidateController(_mockCandidateService.Object, _mockValidator.Object);
    }


    /// <summary>
    /// Upsert candidate with valid request returns ok result
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task UpsertCandidate_WithValidRequest_ReturnsOkResult()
    {
        // Arrange
        var request = new CandidateRequestModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Comments = "Test comments",
            PhoneNumber = "+1234567890",
            LinkedInUrl = "https://linkedin.com/in/johndoe",
            GitHubUrl = "https://github.com/johndoe",
            PreferredCallTime = new PreferredCallTime
            {
                Start = DateTime.UtcNow.AddMinutes(2),
                End = DateTime.UtcNow.AddMinutes(32)
            }
        };

        var response = new CandidateResponseModel
        {
            Id = "abc123",
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Comments = request.Comments,
            PhoneNumber = request.PhoneNumber,
            LinkedInUrl = request.LinkedInUrl,
            GitHubUrl = request.GitHubUrl,
            PreferredCallTime = request.PreferredCallTime,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = null
        };

        _mockValidator
            .Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        _mockCandidateService
            .Setup(x => x.CreateOrUpdateCandidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.UpsertCandidate(request, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCandidate = Assert.IsType<CandidateResponseModel>(okResult.Value);
        Assert.Equal(response.Id, returnedCandidate.Id);
        Assert.Equal(response.FirstName, returnedCandidate.FirstName);
        Assert.Equal(response.LastName, returnedCandidate.LastName);
        Assert.Equal(response.Email, returnedCandidate.Email);
        Assert.Equal(response.Comments, returnedCandidate.Comments);
        Assert.Equal(response.PhoneNumber, returnedCandidate.PhoneNumber);
        Assert.Equal(response.LinkedInUrl, returnedCandidate.LinkedInUrl);
        Assert.Equal(response.GitHubUrl, returnedCandidate.GitHubUrl);
        Assert.Equal(response.PreferredCallTime?.Start, returnedCandidate.PreferredCallTime?.Start);
        Assert.Equal(response.PreferredCallTime?.End, returnedCandidate.PreferredCallTime?.End);
    }

    /// <summary>
    /// Upsert candidate when service throws exception throws exception
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task UpsertCandidate_WhenServiceThrowsException_ThrowsException()
    {
        // Arrange
        var request = new CandidateRequestModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Comments = "Test comments"
        };

        _mockValidator
            .Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        _mockCandidateService
            .Setup(x => x.CreateOrUpdateCandidateAsync(request, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Service error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _controller.UpsertCandidate(request, CancellationToken.None));
    }
}
