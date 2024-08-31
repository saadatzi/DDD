using System.Text.Json;

namespace SSS.Api.Middelware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

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
    
    // Custom method to handle exceptions
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        // Log the exception (optional, but recommended)
        // E.g., using a logger: _logger.LogError(ex, "An error occurred while processing the request.");

        // Set the response details
        context.Response.StatusCode = StatusCodes.Status500InternalServerError; // Internal Server Error
        context.Response.ContentType = "application/json";

        // Construct a response object
        var response = new
        {
            message = "An error occurred while processing your request.",
            error = ex.Message // Optionally include error details
        };

        // Serialize the response to JSON and write it to the response body
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
