namespace ReqNRollPlayground.Domain.Entity;

/// <summary>
/// Entidade que representa um sumário financeiro
/// </summary>
public class FinancialSummary : Entity
{
    /// <summary>
    /// Período (mês/ano) do sumário
    /// </summary>
    public string Period { get; set; }

    /// <summary>
    /// Total de receitas no período
    /// </summary>
    public decimal TotalIncome { get; set; }

    /// <summary>
    /// Total de despesas no período
    /// </summary>
    public decimal TotalOutcome { get; set; }

    /// <summary>
    /// Saldo líquido (Receitas - Despesas)
    /// </summary>
    public decimal NetBalance { get; set; }

    /// <summary>
    /// Data de início do período
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Data de término do período
    /// </summary>
    public DateTime EndDate { get; set; }

    public FinancialSummary()
    {
        Period = string.Empty;
        TotalIncome = 0;
        TotalOutcome = 0;
        NetBalance = 0;
        StartDate = DateTime.UtcNow;
        EndDate = DateTime.UtcNow;
    }

    public FinancialSummary(string period, DateTime startDate, DateTime endDate)
    {
        Period = period;
        StartDate = startDate;
        EndDate = endDate;
        TotalIncome = 0;
        TotalOutcome = 0;
        NetBalance = 0;
    }

    /// <summary>
    /// Calcula o saldo líquido
    /// </summary>
    public void CalculateNetBalance()
    {
        NetBalance = TotalIncome - TotalOutcome;
    }
}

