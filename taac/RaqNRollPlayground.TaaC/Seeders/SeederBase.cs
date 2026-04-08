using Microsoft.EntityFrameworkCore;

namespace RaqNRollPlayground.TaaC.Seeders;

/// <summary>
/// Classe abstrata base para preenchimento de dados iniciais em um contexto de banco de dados.
/// Fornece funcionalidade comum para operações de preenchimento de dados com comportamento personalizável.
/// </summary>
/// <typeparam name="TContext">O tipo do DbContext do Entity Framework a ser preenchido.</typeparam>
public abstract class SeederBase<TContext> : ISeeder where TContext : DbContext
{

    public virtual int Order => 0;
    
    /// <summary>
    /// Método abstrato que as classes derivadas devem implementar para definir a lógica de preenchimento de dados.
    /// </summary>
    /// <param name="context">O contexto do banco de dados a ser preenchido.</param>
    /// <param name="cancellationToken">Token de cancelamento para suportar cancelamento assíncrono.</param>
    /// <returns>Uma tarefa que representa a operação de preenchimento assíncrona.</returns>
    protected abstract Task SeedAsync(TContext context, CancellationToken cancellationToken);
    
    /// <inheritdoc cref="ISeeder.Seed(DbContext, CancellationToken)"/>
    async Task ISeeder.SeedAsync(DbContext context, CancellationToken cancellationToken)
        => await SeedAsync((TContext) context, cancellationToken);
    
    /// <summary>
    /// Preenche dados no banco de dados apenas se a tabela de entidade estiver vazia.
    /// Verifica dados existentes antes de inserir para evitar preenchimento duplicado em execuções repetidas.
    /// </summary>
    /// <typeparam name="TEntity">O tipo de entidade a ser preenchida.</typeparam>
    /// <param name="context">O contexto do banco de dados a ser usado para preenchimento.</param>
    /// <param name="dbSet">O DbSet que representa a coleção de entidade no contexto.</param>
    /// <param name="entities">As entidades a serem preenchidas no banco de dados.</param>
    /// <param name="cancellationToken">Token de cancelamento para suportar cancelamento assíncrono.</param>
    /// <returns>Uma tarefa que representa a operação de preenchimento assíncrona.</returns>
    /// <remarks>
    /// Este método é ideal para dados de desenvolvimento/testes que devem ser inseridos apenas uma vez.
    /// Se os dados já existem, a operação é ignorada completamente.
    /// </remarks>
    protected async Task SeedIfEmptyAsync<TEntity>(
        TContext context,
        DbSet<TEntity> dbSet,
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
        where TEntity : class
    {
        if (await context.Set<TEntity>().AnyAsync(cancellationToken)) return;
        
        await dbSet.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Preenche dados no banco de dados toda vez que é chamado, substituindo ou adicionando aos dados existentes.
    /// Nenhuma verificação de existência é executada; todas as entidades fornecidas são adicionadas ao banco de dados.
    /// </summary>
    /// <typeparam name="TEntity">O tipo de entidade a ser preenchida.</typeparam>
    /// <param name="context">O contexto do banco de dados a ser usado para preenchimento.</param>
    /// <param name="dbSet">O DbSet que representa a coleção de entidade no contexto.</param>
    /// <param name="entities">As entidades a serem preenchidas no banco de dados.</param>
    /// <param name="cancellationToken">Token de cancelamento para suportar cancelamento assíncrono.</param>
    /// <returns>Uma tarefa que representa a operação de preenchimento assíncrona.</returns>
    /// <remarks>
    /// Este método é útil para dados de teste ou cenários onde os dados precisam ser redefinidos a cada execução.
    /// Use com cuidado em produção para evitar duplicação de dados não intencional.
    /// </remarks>
    protected async Task SeedAlwaysAsync<TEntity>(
        TContext context,
        DbSet<TEntity> dbSet,
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
        where TEntity : class
    {
        await dbSet.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
