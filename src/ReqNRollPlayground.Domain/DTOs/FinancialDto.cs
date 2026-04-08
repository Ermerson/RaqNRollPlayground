namespace ReqNRollPlayground.Domain.DTOs;

/// <summary>
/// DTO para representar uma transação (receita ou despesa)
/// </summary>
public class TransactionDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// DTO para representar o sumário financeiro
/// </summary>
public class FinancialSummaryDto
{
    public string Period { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalOutcome { get; set; }
    public decimal NetBalance { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

/// <summary>
/// DTO para representar o relatório de despesas por categoria
/// </summary>
public class OutcomeByCategodyDto
{
    public string Category { get; set; }
    public decimal Total { get; set; }
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

/// <summary>
/// DTO para representar o relatório completo de despesas
/// </summary>
public class OutcomeSummaryReportDto
{
    public string Period { get; set; }
    public decimal TotalOutcomes { get; set; }
    public int OutcomeCount { get; set; }
    public decimal AverageOutcome { get; set; }
    public List<OutcomeByCategodyDto> OutcomesByCategory { get; set; }
    public List<TransactionDto> LatestOutcomes { get; set; }
}

/// <summary>
/// DTO para representar o relatório completo de receitas
/// </summary>
public class IncomeSummaryReportDto
{
    public string Period { get; set; }
    public decimal TotalIncomes { get; set; }
    public int IncomeCount { get; set; }
    public decimal AverageIncome { get; set; }
    public List<OutcomeByCategodyDto> IncomesByCategory { get; set; }
    public List<TransactionDto> LatestIncomes { get; set; }
}

/// <summary>
/// DTO para representar o relatório financeiro completo
/// </summary>
public class FinancialReportDto
{
    public FinancialSummaryDto Summary { get; set; }
    public OutcomeSummaryReportDto OutcomeSummary { get; set; }
    public IncomeSummaryReportDto IncomeSummary { get; set; }
}

