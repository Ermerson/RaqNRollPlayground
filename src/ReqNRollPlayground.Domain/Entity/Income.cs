namespace ReqNRollPlayground.Domain.Entity;

/// <summary>
/// Entidade que representa uma receita/entrada no sistema financeiro
/// </summary>
public class Income : Entity
{
    /// <summary>
    /// Descrição da receita
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Valor da receita
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Data da receita
    /// </summary>
    public DateTime IncomeDate { get; set; }

    /// <summary>
    /// Categoria da receita (ex: Salário, Freelance, Investimento)
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Notas adicionais sobre a receita
    /// </summary>
    public string? Notes { get; set; }

    public Income()
    {
        Description = string.Empty;
        Category = string.Empty;
        IncomeDate = DateTime.Now.ToUniversalTime();
    }

    public Income(string description, decimal amount, string category, DateTime incomeDate)
    {
        Description = description;
        Amount = amount;
        Category = category;
        IncomeDate = incomeDate;
        Notes = null;
    }
}

