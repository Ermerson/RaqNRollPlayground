

using ReqNRollPlayground.Domain.RequestContext;

namespace RaqNRollPlayground.Middlewares;

public class RequestContextMiddleware
{
    private readonly RequestDelegate _next;
    
    public RequestContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext, IRequestContext requestContext)
    {
        var endpoint = httpContext.GetEndpoint();
        
        var sourceContextName = endpoint?.Metadata.GetMetadata<RequestContextSourceAttribute>()?.SourceContextName;
        
        if (sourceContextName == null)
        {
            await _next(httpContext);
            return;
        }
        
        requestContext.SetSourceContextName(sourceContextName);
        
        var period = httpContext.Request.RouteValues["period"]?.ToString(); 
        
        if (!string.IsNullOrEmpty(period))
        {
            requestContext.SetPeriod(period);
        }
        
        await _next(httpContext);
    }
}