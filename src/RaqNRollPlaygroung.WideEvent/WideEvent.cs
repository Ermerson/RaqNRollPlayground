namespace RaqNRollPlaygroung.WideEvent;

public static class WideEvent
{
    private static readonly AsyncLocal<WideEventContext?> _context = new();
    
    public static WideEventContext? Current 
        => _context.Value ??= new WideEventContext();
    
    public static void Reset()
        => _context.Value = null;
}