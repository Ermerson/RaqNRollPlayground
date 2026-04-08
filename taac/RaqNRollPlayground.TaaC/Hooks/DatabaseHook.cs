using RaqNRollPlayground.Infra.Context;
using RaqNRollPlayground.TaaC.Seeders;
using RaqNRollPlayground.TaaC.Seeders.Scripts;
using Reqnroll;

namespace RaqNRollPlayground.TaaC.Hooks;

[Binding]
public class DatabaseHook
{
    [BeforeFeature("@database")]
    public static async Task BeforeFeature(FinancialContext dbContext)
    {
        await using var scope = new SeederScope(dbContext);
        scope.Add<IncomeOutcomeSeeder>();
        await scope.RunAsync();
    }
    
    [AfterFeature("@database")]
    public static async Task AfterFeature(FinancialContext dbContext)
    {
        // Remover todos os registros do banco, mantendo as tabelas
        dbContext.FinancialSummaries.RemoveRange(dbContext.FinancialSummaries);
        dbContext.Incomes.RemoveRange(dbContext.Incomes);
        dbContext.Outcomes.RemoveRange(dbContext.Outcomes);
        
        await dbContext.SaveChangesAsync();
    }
}