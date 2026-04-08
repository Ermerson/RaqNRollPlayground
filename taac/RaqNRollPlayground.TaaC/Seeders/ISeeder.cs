using Microsoft.EntityFrameworkCore;

namespace RaqNRollPlayground.TaaC.Seeders;

public interface ISeeder
{
    /// <summary>
    /// Obtém a ordem em que este seeder deve ser executado em relação a outros seeders.
    /// Os seeders são executados em ordem ascendente por este valor.
    /// Sobrescreva esta propriedade para controlar a sequência de preenchimento.
    /// </summary>
    /// <remarks>
    /// O valor padrão é 0. Valores mais altos executam depois.
    /// </remarks>
    int Order { get; }
    
    /// <summary>
    /// Implementação explícita da interface <see cref="ISeeder.Seed"/>.
    /// Converte o DbContext genérico para o tipo de contexto específico e chama SeedAsync.
    /// </summary>
    /// <param name="context">O contexto do banco de dados a ser preenchido.</param>
    /// <param name="cancellationToken">Token de cancelamento para suportar cancelamento assíncrono.</param>
    /// <returns>Uma tarefa que representa a operação de preenchimento assíncrona.</returns>
    Task SeedAsync(DbContext context, CancellationToken cancellationToken = default);
}