using System.Diagnostics;

namespace DevTrackPro.Middleware;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    // The middleware receives the "next" piece of the pipeline and a Logger
    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    // This method is called automatically for every single HTTP request
    public async Task InvokeAsync(HttpContext context)
    {
        // TODO 1: Create and start a new System.Diagnostics.Stopwatch
        var stopwatch = Stopwatch.StartNew();
        
        // This line passes control to the next middleware (and eventually your Controller)
        await _next(context);

        // TODO 2: Stop the stopwatch
        stopwatch.Stop();
        
        // TODO 3: Use _logger.LogInformation() to print out:
        // The HTTP Method (e.g., GET)
        // The URL Path (e.g., /api/employees)
        // The time taken in milliseconds
        // Hint: You can get the method and path from context.Request.Method and context.Request.Path
       _logger.LogInformation(
    "Request {Method} {Path} took {ElapsedMilliseconds} ms", 
    context.Request.Method, 
    context.Request.Path, 
    stopwatch.ElapsedMilliseconds);
    }
}