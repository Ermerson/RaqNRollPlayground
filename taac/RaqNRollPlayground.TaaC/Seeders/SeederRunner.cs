using Microsoft.EntityFrameworkCore;

namespace RaqNRollPlayground.TaaC.Seeders;

public class SeederRunner(DbContext context, IEnumerable<ISeeder> seeders)
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        foreach (var seeder in seeders.OrderBy(s => s.Order))
        {
            await seeder.SeedAsync(context, cancellationToken);
        }
    }
}