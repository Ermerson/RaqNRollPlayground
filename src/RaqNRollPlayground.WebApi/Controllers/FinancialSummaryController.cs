using Microsoft.AspNetCore.Mvc;
using ReqNRollPlayground.Domain.DTOs;
using ReqNRollPlayground.Domain.Services;

namespace RaqNRollPlayground.Controllers;

/// <summary>
/// Controller para operações de sumário financeiro
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FinancialSummaryController : ControllerBase
{
    private readonly IFinancialService _financialService;

    public FinancialSummaryController(IFinancialService financialService)
    {
        _financialService = financialService;
    }

    /// <summary>
    /// Obter sumário de despesas para um período específico
    /// </summary>
    /// <param name="period">Período no formato "yyyy-MM" (ex: 2026-04)</param>
    /// <returns>Sumário de despesas agrupadas por categoria</returns>
    [HttpGet("outcomes/{period}")]
    public async Task<ActionResult<OutcomeSummaryReportDto>> GetOutcomeSummary(string period)
    {
        if (!IsValidPeriod(period))
            return BadRequest(new { message = "Período inválido. Use o formato 'yyyy-MM'" });

        try
        {
            var result = await _financialService.GetOutcomeSummaryAsync(period);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Obter sumário de receitas para um período específico
    /// </summary>
    /// <param name="period">Período no formato "yyyy-MM" (ex: 2026-04)</param>
    /// <returns>Sumário de receitas agrupadas por categoria</returns>
    [HttpGet("incomes/{period}")]
    public async Task<ActionResult<IncomeSummaryReportDto>> GetIncomeSummary(string period)
    {
        if (!IsValidPeriod(period))
            return BadRequest(new { message = "Período inválido. Use o formato 'yyyy-MM'" });

        try
        {
            var result = await _financialService.GetIncomeSummaryAsync(period);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Obter relatório financeiro completo para um período específico
    /// </summary>
    /// <param name="period">Período no formato "yyyy-MM" (ex: 2026-04)</param>
    /// <returns>Relatório com receitas, despesas e sumário</returns>
    [HttpGet("report/{period}")]
    public async Task<ActionResult<FinancialReportDto>> GetFinancialReport(string period)
    {
        if (!IsValidPeriod(period))
            return BadRequest(new { message = "Período inválido. Use o formato 'yyyy-MM'" });

        try
        {
            var result = await _financialService.GetFinancialReportAsync(period);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Obter sumário do mês atual
    /// </summary>
    /// <returns>Sumário financeiro do mês atual</returns>
    [HttpGet("current-month")]
    public async Task<ActionResult<FinancialSummaryDto>> GetCurrentMonthSummary()
    {
        try
        {
            var result = await _financialService.GetCurrentMonthSummaryAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Validar formato do período
    /// </summary>
    private static bool IsValidPeriod(string period)
    {
        return DateTime.TryParse($"{period}-01", out _);
    }
}

