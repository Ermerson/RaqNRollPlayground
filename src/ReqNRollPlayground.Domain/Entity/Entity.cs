namespace ReqNRollPlayground.Domain.Entity;

/// <summary>
/// Classe base para todas as entidades do domínio
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Identificador único da entidade
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Data de criação da entidade
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Data da última atualização da entidade
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Indica se a entidade está ativa
    /// </summary>
    public bool IsActive { get; set; }

    protected Entity()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity entity)
            return false;

        return Id == entity.Id && GetType() == entity.GetType();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id = {Id}]";
    }
}

