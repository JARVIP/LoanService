using System.Text.Json;

namespace LoanService.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = new ErrorResponse();

        switch (exception)
        {
            case ArgumentException argEx:
            case InvalidOperationException invOpEx:
                response.Status = 400;
                response.Title = "Bad Request";
                response.Detail = exception.Message;
                _logger.LogWarning(exception, "Validation error: {Message}", exception.Message);
                break;
            case UnauthorizedAccessException unauthEx:
                response.Status = 401;
                response.Title = "Unauthorized";
                response.Detail = exception.Message;
                _logger.LogWarning(exception, "Unauthorized: {Message}", exception.Message);
                break;
            case KeyNotFoundException keyNotFoundEx:
                response.Status = 404;
                response.Title = "Not Found";
                response.Detail = exception.Message;
                _logger.LogWarning(exception, "Not Found: {Message}", exception.Message);
                break;
            case NotImplementedException notImplEx:
                response.Status = 501;
                response.Title = "Not Implemented";
                response.Detail = exception.Message;
                _logger.LogWarning(exception, "Not Implemented: {Message}", exception.Message);
                break;
            default:
                response.Status = 500;
                response.Title = "Internal Server Error";
                response.Detail = "An unexpected error occurred.";
                _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
                break;
        }

        context.Response.StatusCode = response.Status;
        var jsonResponse = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonResponse);
    }
}

public class ErrorResponse
{
    public int Status { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Detail { get; set; }
} 