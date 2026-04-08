using ReqNRollPlayground.Domain.Entity;
using RaqNRollPlayground.Infra.Context;

namespace RaqNRollPlayground.Infra.Seeders;

/// <summary>
/// Classe responsável por popular o banco de dados com dados iniciais
/// </summary>
public static class DatabaseSeeder
{
    /// <summary>
    /// Aplica o seeding ao banco de dados
    /// </summary>
    public static void Seed(FinancialContext context)
    {
        // Verifica se já existe dados
        if (context.Incomes.Any() || context.Outcomes.Any())
            return;

        // Criar receitas de exemplo
        var incomes = new List<Income>
        {
            new Income
            {
                Description = "Salário Mensal",
                Amount = 5000.00m,
                Category = "Salário",
                IncomeDate = new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Salário referente ao mês de abril",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Income
            {
                Description = "Freelance - Projeto Web",
                Amount = 1500.00m,
                Category = "Freelance",
                IncomeDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Trabalho de desenvolvimento web",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Income
            {
                Description = "Rendimento de Investimento",
                Amount = 250.00m,
                Category = "Investimento",
                IncomeDate = new DateTime(2026, 4, 10, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Rendimento mensal da aplicação",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Income
            {
                Description = "Bônus",
                Amount = 800.00m,
                Category = "Bônus",
                IncomeDate = new DateTime(2026, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Bônus de desempenho",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        // Criar despesas de exemplo
        var outcomes = new List<Outcome>
        {
            new Outcome
            {
                Description = "Aluguel do Apartamento",
                Amount = 1500.00m,
                Category = "Moradia",
                OutcomeDate = new DateTime(2026, 4, 3, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Aluguel referente a abril",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Supermercado",
                Amount = 450.00m,
                Category = "Alimentação",
                OutcomeDate = new DateTime(2026, 4, 2, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Compras no supermercado",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Passagem de Ônibus",
                Amount = 150.00m,
                Category = "Transporte",
                OutcomeDate = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Recarreg do cartão de transporte",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Conta de Energia",
                Amount = 320.00m,
                Category = "Utilitários",
                OutcomeDate = new DateTime(2026, 4, 6, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Fatura de energia elétrica",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Internet",
                Amount = 99.90m,
                Category = "Utilitários",
                OutcomeDate = new DateTime(2026, 4, 6, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Conta de internet",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Restaurante",
                Amount = 85.00m,
                Category = "Alimentação",
                OutcomeDate = new DateTime(2026, 4, 7, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Almoço com amigos",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Cinema",
                Amount = 60.00m,
                Category = "Lazer",
                OutcomeDate = new DateTime(2026, 4, 12, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Sessão de cinema",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Outcome
            {
                Description = "Plano de Streaming",
                Amount = 29.90m,
                Category = "Lazer",
                OutcomeDate = new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                Notes = "Assinatura mensal",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        // Adicionar os registros ao contexto
        context.Incomes.AddRange(incomes);
        context.Outcomes.AddRange(outcomes);

        // Criar sumário financeiro
        decimal totalIncome = incomes.Sum(i => i.Amount);
        decimal totalOutcome = outcomes.Sum(o => o.Amount);
        decimal netBalance = totalIncome - totalOutcome;

        var summary = new FinancialSummary
        {
            Period = "2026-04",
            TotalIncome = totalIncome,
            TotalOutcome = totalOutcome,
            NetBalance = netBalance,
            StartDate = new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc),
            EndDate = new DateTime(2026, 4, 30, 23, 59, 59, DateTimeKind.Utc),
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.FinancialSummaries.Add(summary);

        // Salvar todas as mudanças
        context.SaveChanges();
    }
}

