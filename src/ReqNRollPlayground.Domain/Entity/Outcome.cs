namespace ReqNRollPlayground.Domain.Entity;

/// <summary>
/// Entidade que representa uma despesa/saída no sistema financeiro
/// </summary>
public class Outcome : Entity
{
    /// <summary>
    /// Descrição da despesa
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Valor da despesa
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Data da despesa
    /// </summary>
    public DateTime OutcomeDate { get; set; }

    /// <summary>
    /// Categoria da despesa (ex: Alimentação, Transporte, Moradia)
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Notas adicionais sobre a despesa
    /// </summary>
    public string? Notes { get; set; }

    public Outcome()
    {
        Description = string.Empty;
        Category = string.Empty;
        OutcomeDate = DateTime.Now.ToUniversalTime();
    }

    public Outcome(string description, decimal amount, string category, DateTime outcomeDate)
    {
        Description = description;
        Amount = amount;
        Category = category;
        OutcomeDate = outcomeDate;
        Notes = null;
    }
}

