using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RaqNRollPlayground.TaaC.Seeders;

public static class SeederExtensions
{
       public static IServiceCollection AddSeeders(this IServiceCollection services)
       {
              var seederType = typeof(ISeeder);
              var seeders = Assembly.GetExecutingAssembly()
                     .GetTypes()
                     .Where(t => seederType.IsAssignableFrom(t) &&
                                 t is { IsAbstract: false, IsInterface: false });

              foreach (var seeder in seeders)
                     services.AddScoped(seeder);
              
              services.AddScoped<SeederRunner>();
              return services;
       }
}