using Microsoft.EntityFrameworkCore;
using ReqNRollPlayground.Domain.Entity;

namespace RaqNRollPlayground.Infra.Context;

/// <summary>
/// Contexto do Entity Framework para o banco de dados PostgreSQL
/// </summary>
public class FinancialContext : DbContext
{
    /// <summary>
    /// DbSet para as receitas
    /// </summary>
    public DbSet<Income> Incomes { get; set; }

    /// <summary>
    /// DbSet para as despesas
    /// </summary>
    public DbSet<Outcome> Outcomes { get; set; }

    /// <summary>
    /// DbSet para os sumários financeiros
    /// </summary>
    public DbSet<FinancialSummary> FinancialSummaries { get; set; }

    public FinancialContext(DbContextOptions<FinancialContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Converter automático para UTC para todas as propriedades DateTime
        var dateTimeConverter = new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        // Configurações para Income
        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IncomeDate).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.UpdatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
        });

        // Configurações para Outcome
        modelBuilder.Entity<Outcome>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            entity.Property(e => e.OutcomeDate).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.UpdatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
        });

        // Configurações para FinancialSummary
        modelBuilder.Entity<FinancialSummary>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Period).IsRequired().HasMaxLength(10);
            entity.Property(e => e.TotalIncome).HasPrecision(18, 2);
            entity.Property(e => e.TotalOutcome).HasPrecision(18, 2);
            entity.Property(e => e.NetBalance).HasPrecision(18, 2);
            entity.Property(e => e.StartDate).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.EndDate).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.CreatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.UpdatedAt).IsRequired().HasConversion(dateTimeConverter);
            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
        });
    }
}

