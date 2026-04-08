namespace RaqNRollPlayground.TaaC.Seeders;

public class EntityBuilder<T> where T : class, new()
{
    private readonly List<Action<T>> _mutations = [];
    private Func<T>? _factory;

    public EntityBuilder<T> UseFactory(Func<T> factory)
    {
        _factory = factory;
        return this;
    }
    
    public EntityBuilder<T> With(Action<T> mutation)
    {
        _mutations.Add(mutation);
        return this;
    }

    public T Build()
    {
        var entity = _factory?.Invoke() ?? new T();
        
        _mutations.ForEach(m => m(entity));
        return entity;
    }
    
    public List<T> BuildMany(int count, Action<T, int>? indexedMutation = null)
    {
        return Enumerable.Range(0, count).Select(i =>
        {
            var entity = Build();
            indexedMutation?.Invoke(entity, i);
            return entity;
        }).ToList();
    }
}