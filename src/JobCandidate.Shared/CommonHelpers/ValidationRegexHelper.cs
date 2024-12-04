using System.Text.RegularExpressions;

namespace JobCandidate.Shared.CommonHelpers;

/// <summary>
/// Helper class for validation using regular expressions.
/// </summary>
public static class ValidationRegexHelper
{
    private static readonly TimeSpan RegexTimeout = TimeSpan.FromMilliseconds(500);

    /// <summary>
    /// Validates if the provided email is in a correct format.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>True if the email is valid, otherwise false.</returns>
    public static bool ValidEmail(string email)
    {
        // Matches:
        // example@example.com
        // example.123@sub.example.com
        // example-123@sub.example.com
        // example_123@sub.example.com
        const string emailRegex =
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}"
            + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\"
            + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        return new Regex(emailRegex, RegexOptions.None, RegexTimeout).IsMatch(email);
    }

    /// <summary>
    /// Validates if the provided mobile number is in correct format.
    /// </summary>
    /// <param name="mobileNumber">The mobile number to validate.</param>
    /// <returns>True if the mobile number is valid, otherwise false.</returns>
    public static bool ValidMobileNumber(string mobileNumber)
    {
        // Matches:
        // +1 (123) 456-7890
        // (123) 456-7890
        // 123-456-7890
        // 1234567890
        const string mobilePattern = @"^\+?1?\s*(\(\d{3}\)|\d{3})[-.\s]*\d{3}[-.\s]*\d{4}$";
        return new Regex(mobilePattern, RegexOptions.None, RegexTimeout).IsMatch(mobileNumber);
    }
}

