using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using RaqNRollPlayground.Infra.Context;
using RaqNRollPlayground.TaaC.HttpClients;

namespace RaqNRollPlayground.TaaC.DI;

public static class Dependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        
        services.AddHttpClient("FinancialAPI");
        
        services.AddScoped<FinancialSummaryApiClient>();
        
        services.AddDbContext<FinancialContext>(options =>
            options
                .UseNpgsql("Host=localhost;Port=5432;Database=financial_control;Username=postgres;Password=postgres"));
        return services;
    }
}