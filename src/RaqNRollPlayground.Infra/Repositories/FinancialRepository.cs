using Microsoft.EntityFrameworkCore;
using ReqNRollPlayground.Domain.Entity;
using ReqNRollPlayground.Domain.Services;
using RaqNRollPlayground.Infra.Context;

namespace RaqNRollPlayground.Infra.Repositories;

/// <summary>
/// Implementação do repositório financeiro
/// </summary>
public class FinancialRepository : IFinancialRepository
{
    private readonly FinancialContext _context;

    public FinancialRepository(FinancialContext context)
    {
        _context = context;
    }

    public async Task<List<Outcome>> GetOutcomesByPeriodAsync(string period)
    {
        // Esperado formato: "2026-04"
        if (!DateTime.TryParse($"{period}-01", out var startDate))
            return new List<Outcome>();

        var endDate = startDate.AddMonths(1).AddTicks(-1);

        return await _context.Outcomes
            .Where(o => o.IsActive && o.OutcomeDate >= startDate && o.OutcomeDate <= endDate)
            .OrderByDescending(o => o.OutcomeDate)
            .ToListAsync();
    }

    public async Task<List<Income>> GetIncomesByPeriodAsync(string period)
    {
        // Esperado formato: "2026-04"
        if (!DateTime.TryParse($"{period}-01", out var startDate))
            return new List<Income>();

        var endDate = startDate.AddMonths(1).AddTicks(-1);

        return await _context.Incomes
            .Where(i => i.IsActive && i.IncomeDate >= startDate && i.IncomeDate <= endDate)
            .OrderByDescending(i => i.IncomeDate)
            .ToListAsync();
    }

    public async Task<FinancialSummary?> GetFinancialSummaryAsync(string period)
    {
        return await _context.FinancialSummaries
            .FirstOrDefaultAsync(fs => fs.Period == period && fs.IsActive);
    }
}

