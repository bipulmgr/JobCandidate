using System.Net;
using System.Text.Json;
using JobCandidate.Shared.Exceptions;

namespace JobCandidate.Api.Middleware;
/// <summary>
/// Middleware for handling exceptions and returning appropriate HTTP responses.
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger.</param>
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// Handles the exception asynchronously.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new { errors = validationException.Errors });
                break;
            case FluentValidation.ValidationException fluentValidationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new { errors = fluentValidationException.Errors });
                break;
            case NotFoundException _:
                code = HttpStatusCode.NotFound;
                break;
            default:
                _logger.LogError(exception, "An unhandled exception has occurred");
                result = JsonSerializer.Serialize(
                    new { error = "An error occurred processing your request" }
                );
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
