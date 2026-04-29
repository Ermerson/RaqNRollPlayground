namespace RaqNRollPlaygroung.WideEvent;

public class WideEventContext
{
    private readonly Dictionary<string, object?> _context = new();

    public void Add(string key, object? value)
    {
        if (value is null)
            return;
        
        _context[key] = value;
    }
    
    public IReadOnlyDictionary<string, object?> Snapshot()
        => _context;
}