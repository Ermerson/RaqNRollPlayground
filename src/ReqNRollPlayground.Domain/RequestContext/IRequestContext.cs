using Microsoft.Extensions.DependencyInjection;

namespace ReqNRollPlayground.Domain.RequestContext;

public interface IRequestContext
{
    public string? Period { get; }

    public string? SourceContextName { get; }
    public void SetPeriod(string period);
    
    public void SetSourceContextName(string name);
}

public class RequestContext : IRequestContext
{
    public string? Period { get; private set; }
    public string? SourceContextName { get; private set;} = string.Empty;

    public void SetPeriod(string period)
    {
        Period = period;
    }

    public void SetSourceContextName(string name)
    {
        SourceContextName = name;
    }
}

public static class RequestContextExtension
{
    public static IServiceCollection AddRequestContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRequestContext, RequestContext>();
        return serviceCollection;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class RequestContextSourceAttribute : Attribute
{
    public RequestContextSourceAttribute(string sourceContextName)
    {
        SourceContextName = sourceContextName;
    }
    
    public string SourceContextName { get; }
}