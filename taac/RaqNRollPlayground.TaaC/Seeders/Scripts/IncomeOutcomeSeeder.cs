using RaqNRollPlayground.Infra.Context;
using ReqNRollPlayground.Domain.Entity;

namespace RaqNRollPlayground.TaaC.Seeders.Scripts;

public class IncomeOutcomeSeeder : SeederBase<FinancialContext>
{
    public override int Order => 1;
    
    protected override async Task SeedAsync(FinancialContext context, CancellationToken cancellationToken)
    {
        await SeedIncomesAsync(context, cancellationToken);
        await SeedOutcomesAsync(context, cancellationToken);
    }
    
    private Task SeedIncomesAsync(FinancialContext context, CancellationToken cancellationToken)
    {
        if (context.Incomes.Any())
            return Task.CompletedTask;
        
        var incomes = new EntityBuilder<Income>()
            .With(i =>
            {
                i.Description = "Salário";
                i.Amount = 5000m;
                i.IncomeDate = DateTime.UtcNow.AddDays(-10);
            })
            .With(i =>
            {
                i.Description = "Freelance";
                i.Amount = 1500m;
                i.IncomeDate = DateTime.UtcNow.AddDays(-5);
            })
            .BuildMany(10, (i, index) =>
            {
                i.Description += $" #{index + 1}";
                i.Amount += index * 100;
                i.IncomeDate = i.IncomeDate.AddDays(index);
            });
        
        return SeedIfEmptyAsync(context, context.Incomes, incomes, cancellationToken);
    }
    
    private Task SeedOutcomesAsync(FinancialContext context, CancellationToken ct)
    {
        var outcomes = new EntityBuilder<Outcome>()
            .With(e => e.CreatedAt = DateTime.UtcNow)
            .With(e => e.IsActive = true)
            .BuildMany(count: 30, indexedMutation: (outcome, i) =>
            {
                outcome.Description = Descriptions[i % Descriptions.Length];
                outcome.Amount = 100m + (i * 50m);
                outcome.OutcomeDate = DateTime.UtcNow.AddDays(-i * 3);
                outcome.Category = Descriptions[(i % 4) + 1];
            });

        return SeedIfEmptyAsync(context, context.Outcomes, outcomes, ct);
    }

    private static readonly string[] Descriptions =
    [
        "Aluguel", "Mercado", "Conta de luz", "Internet",
        "Combustível", "Plano de saúde", "Streaming", "Academia"
    ];
}