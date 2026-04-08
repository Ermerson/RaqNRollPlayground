using Microsoft.EntityFrameworkCore;

namespace RaqNRollPlayground.TaaC.Seeders;

public class SeederScope : IAsyncDisposable
{
    private readonly DbContext _context;
    private readonly List<ISeeder> _seeders = [];

    public SeederScope(DbContext context)
    {
        _context = context;
    }
    
    public SeederScope Add<TSeeder>() where TSeeder : ISeeder, new()
    {
        _seeders.Add(new TSeeder());
        return this;
    }

    public SeederScope Add(ISeeder seeder)
    {
        _seeders.Add(seeder);
        return this;
    }

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var runner = new SeederRunner(_context, _seeders);
        return runner.RunAsync(cancellationToken);
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}