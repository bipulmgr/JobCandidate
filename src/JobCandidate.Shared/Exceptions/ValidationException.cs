namespace JobCandidate.Shared.Exceptions;

/// <summary>
/// Represents errors that occur during application execution due to validation failures.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message and a collection of validation errors.
    /// </summary>
    /// <param name="errors">A dictionary containing validation errors, where the key is the property name and the value is an array of error messages.</param>
    public ValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets a dictionary of property names and their associated validation error messages.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }
}
