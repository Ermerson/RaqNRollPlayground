using ReqNRollPlayground.Domain.DTOs;
using ReqNRollPlayground.Domain.Entity;

namespace ReqNRollPlayground.Domain.Services;

/// <summary>
/// Serviço para operações financeiras
/// </summary>
public interface IFinancialService
{
    /// <summary>
    /// Obter sumário de despesas para um período
    /// </summary>
    Task<OutcomeSummaryReportDto> GetOutcomeSummaryAsync(string period);

    /// <summary>
    /// Obter sumário de receitas para um período
    /// </summary>
    Task<IncomeSummaryReportDto> GetIncomeSummaryAsync(string period);

    /// <summary>
    /// Obter relatório financeiro completo para um período
    /// </summary>
    Task<FinancialReportDto> GetFinancialReportAsync(string period);

    /// <summary>
    /// Obter sumário do mês atual
    /// </summary>
    Task<FinancialSummaryDto> GetCurrentMonthSummaryAsync();
}

/// <summary>
/// Implementação do serviço financeiro
/// </summary>
public class FinancialService : IFinancialService
{
    private readonly IFinancialRepository _repository;

    public FinancialService(IFinancialRepository repository)
    {
        _repository = repository;
    }

    public async Task<OutcomeSummaryReportDto> GetOutcomeSummaryAsync(string period)
    {
        var outcomes = await _repository.GetOutcomesByPeriodAsync(period);

        if (!outcomes.Any())
        {
            return new OutcomeSummaryReportDto
            {
                Period = period,
                TotalOutcomes = 0,
                OutcomeCount = 0,
                AverageOutcome = 0,
                OutcomesByCategory = new List<OutcomeByCategodyDto>(),
                LatestOutcomes = new List<TransactionDto>()
            };
        }

        var totalOutcomes = outcomes.Sum(o => o.Amount);
        var outcomesByCategory = outcomes
            .GroupBy(o => o.Category)
            .Select(g => new OutcomeByCategodyDto
            {
                Category = g.Key,
                Total = g.Sum(o => o.Amount),
                Count = g.Count(),
                Percentage = (g.Sum(o => o.Amount) / totalOutcomes) * 100
            })
            .OrderByDescending(o => o.Total)
            .ToList();

        var latestOutcomes = outcomes
            .OrderByDescending(o => o.OutcomeDate)
            .Take(5)
            .Select(o => new TransactionDto
            {
                Id = o.Id,
                Description = o.Description,
                Amount = o.Amount,
                Category = o.Category,
                Date = o.OutcomeDate,
                Notes = o.Notes
            })
            .ToList();

        return new OutcomeSummaryReportDto
        {
            Period = period,
            TotalOutcomes = totalOutcomes,
            OutcomeCount = outcomes.Count,
            AverageOutcome = outcomes.Average(o => o.Amount),
            OutcomesByCategory = outcomesByCategory,
            LatestOutcomes = latestOutcomes
        };
    }

    public async Task<IncomeSummaryReportDto> GetIncomeSummaryAsync(string period)
    {
        var incomes = await _repository.GetIncomesByPeriodAsync(period);

        if (!incomes.Any())
        {
            return new IncomeSummaryReportDto
            {
                Period = period,
                TotalIncomes = 0,
                IncomeCount = 0,
                AverageIncome = 0,
                IncomesByCategory = new List<OutcomeByCategodyDto>(),
                LatestIncomes = new List<TransactionDto>()
            };
        }

        var totalIncomes = incomes.Sum(i => i.Amount);
        var incomesByCategory = incomes
            .GroupBy(i => i.Category)
            .Select(g => new OutcomeByCategodyDto
            {
                Category = g.Key,
                Total = g.Sum(i => i.Amount),
                Count = g.Count(),
                Percentage = (g.Sum(i => i.Amount) / totalIncomes) * 100
            })
            .OrderByDescending(i => i.Total)
            .ToList();

        var latestIncomes = incomes
            .OrderByDescending(i => i.IncomeDate)
            .Take(5)
            .Select(i => new TransactionDto
            {
                Id = i.Id,
                Description = i.Description,
                Amount = i.Amount,
                Category = i.Category,
                Date = i.IncomeDate,
                Notes = i.Notes
            })
            .ToList();

        return new IncomeSummaryReportDto
        {
            Period = period,
            TotalIncomes = totalIncomes,
            IncomeCount = incomes.Count,
            AverageIncome = incomes.Average(i => i.Amount),
            IncomesByCategory = incomesByCategory,
            LatestIncomes = latestIncomes
        };
    }

    public async Task<FinancialReportDto> GetFinancialReportAsync(string period)
    {
        var summary = await _repository.GetFinancialSummaryAsync(period);
        var outcomeSummary = await GetOutcomeSummaryAsync(period);
        var incomeSummary = await GetIncomeSummaryAsync(period);

        var financialSummaryDto = summary != null
            ? new FinancialSummaryDto
            {
                Period = summary.Period,
                TotalIncome = summary.TotalIncome,
                TotalOutcome = summary.TotalOutcome,
                NetBalance = summary.NetBalance,
                StartDate = summary.StartDate,
                EndDate = summary.EndDate
            }
            : new FinancialSummaryDto
            {
                Period = period,
                TotalIncome = incomeSummary.TotalIncomes,
                TotalOutcome = outcomeSummary.TotalOutcomes,
                NetBalance = incomeSummary.TotalIncomes - outcomeSummary.TotalOutcomes
            };

        return new FinancialReportDto
        {
            Summary = financialSummaryDto,
            OutcomeSummary = outcomeSummary,
            IncomeSummary = incomeSummary
        };
    }

    public async Task<FinancialSummaryDto> GetCurrentMonthSummaryAsync()
    {
        var currentPeriod = DateTime.UtcNow.ToString("yyyy-MM");
        var summary = await _repository.GetFinancialSummaryAsync(currentPeriod);

        if (summary != null)
        {
            return new FinancialSummaryDto
            {
                Period = summary.Period,
                TotalIncome = summary.TotalIncome,
                TotalOutcome = summary.TotalOutcome,
                NetBalance = summary.NetBalance,
                StartDate = summary.StartDate,
                EndDate = summary.EndDate
            };
        }

        // Se não houver sumário, calcular a partir das transações
        var report = await GetFinancialReportAsync(currentPeriod);
        return report.Summary;
    }
}

/// <summary>
/// Interface do repositório financeiro
/// </summary>
public interface IFinancialRepository
{
    Task<List<Outcome>> GetOutcomesByPeriodAsync(string period);
    Task<List<Income>> GetIncomesByPeriodAsync(string period);
    Task<FinancialSummary?> GetFinancialSummaryAsync(string period);
}

