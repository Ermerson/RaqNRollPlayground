using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReqNRollPlayground.Domain.Services;
using RaqNRollPlayground.Infra.Context;
using RaqNRollPlayground.Infra.Repositories;

namespace RaqNRollPlayground.Infra.Configuration;

/// <summary>
/// Extensões para configurar os serviços de infraestrutura
/// </summary>
public static class InfrastructureConfiguration
{
    /// <summary>
    /// Adiciona o DbContext do Financial configurado para PostgreSQL
    /// </summary>
    public static IServiceCollection AddFinancialContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<FinancialContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly("RaqNRollPlayground.Infra");
            }));

        return services;
    }

    /// <summary>
    /// Adiciona os serviços e repositórios da camada de infraestrutura
    /// </summary>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IFinancialRepository, FinancialRepository>();
        services.AddScoped<IFinancialService, FinancialService>();

        return services;
    }
}

