using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RaqNRollPlaygroung.WideEvent;

public class WideEventMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<WideEventMiddleware> _logger;

    public WideEventMiddleware(RequestDelegate next, ILogger<WideEventMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var start = Stopwatch.GetTimestamp();

        try
        {
            WideEvent.Current?.Add("http.method", context.Request.Method);
            WideEvent.Current?.Add("http.path", context.Request.Path);

            await _next(context);

            WideEvent.Current?.Add("http.status_code", context.Response.StatusCode);
        }
        catch (Exception ex)
        {
            WideEvent.Current?.Add("error.type", ex.GetType().Name);
            WideEvent.Current?.Add("error.message", ex.Message);
            throw;
        }
        finally
        {
            var duration = Stopwatch.GetElapsedTime(start).TotalMilliseconds;
            WideEvent.Current?.Add("duration_ms", duration);
            
            _logger.LogInformation("WideEvent {@event}", WideEvent.Current?.Snapshot());

            WideEvent.Reset();
        }
    }
}