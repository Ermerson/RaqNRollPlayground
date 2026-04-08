using Microsoft.EntityFrameworkCore;
using RaqNRollPlayground.Infra.Configuration;
using RaqNRollPlayground.Infra.Context;
using RaqNRollPlayground.Infra.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddFinancialContext(builder.Configuration);
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Aplicar migrações pendentes ao banco de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FinancialContext>();
    context.Database.Migrate();
    
    // Aplicar seeding ao banco de dados
    DatabaseSeeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();