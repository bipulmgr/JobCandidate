using FluentValidation;
using JobCandidate.Core.Models.Request;
using JobCandidate.Shared.CommonHelpers;

namespace JobCandidate.Core.Validators;

/// <summary>
/// Represents a validator for candidate request models.
/// </summary>
public class CandidateRequestValidator : AbstractValidator<CandidateRequestModel>
{
    public CandidateRequestValidator()
    {
        RuleFor(x => x.FirstName).NotNull().NotEmpty()
                    .MaximumLength(50);
        RuleFor(x => x.LastName).NotNull().NotEmpty()
                    .MaximumLength(50);

        RuleFor(x => x.Email).NotNull().NotEmpty()
                    .MaximumLength(200)
                    .Must(x => x == null || ValidationRegexHelper.ValidEmail(x));
        RuleFor(x => x.PhoneNumber)
                    .MaximumLength(15)
                    .Must(x => x == null || ValidationRegexHelper.ValidMobileNumber(x))
                    .WithMessage(
                        "Invalid phone number format. Must be in the format +1 (123) 456-7890, (123) 456-7890, 123-456-7890, or 1234567890"
                    );

        RuleFor(x => x.PreferredCallTime)
            .Must((model, preferredCallTime) =>
            {
                if (preferredCallTime == null)
                    return true;

                return preferredCallTime.Start != DateTime.MinValue
                    && preferredCallTime.End != DateTime.MinValue;
            })
            .WithMessage("When PreferredCallTime is provided, both Start and End times must be specified.")
            .DependentRules(() =>
            {
                RuleFor(x => x.PreferredCallTime!.Start)
                    .GreaterThan(DateTime.UtcNow)
                    .When(x => x.PreferredCallTime != null && x.PreferredCallTime.Start != DateTime.MinValue)
                    .WithMessage("Preferred call start time must be in the future");

                RuleFor(x => x.PreferredCallTime!.End)
                    .GreaterThan(x => x.PreferredCallTime!.Start)
                    .When(x => x.PreferredCallTime != null && x.PreferredCallTime.Start != DateTime.MinValue)
                    .WithMessage("Preferred call end time must be after the start time");
            });

        RuleFor(x => x.LinkedInUrl).MaximumLength(200);
        RuleFor(x => x.GitHubUrl).MaximumLength(200);
        RuleFor(x => x.Comments).NotNull().NotEmpty()
                    .MaximumLength(4000);
    }
}

