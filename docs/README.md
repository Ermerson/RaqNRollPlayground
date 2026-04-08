# 📊 RaqNRoll Playground - Controle Financeiro

## 🎯 Visão Geral

Sistema de controle financeiro simples desenvolvido em .NET 10 com Entity Framework Core e PostgreSQL.

## 📋 Estrutura do Projeto

- **ReqNRollPlayground.Domain**: Camada de domínio com as entidades
  - `Entity`: Classe base abstrata para todas as entidades
  - `Income`: Entidade de receitas
  - `Outcome`: Entidade de despesas
  - `FinancialSummary`: Sumário financeiro

- **RaqNRollPlayground.Infra**: Camada de infraestrutura
  - `FinancialContext`: DbContext configurado para PostgreSQL
  - `InfrastructureConfiguration`: Extensões de configuração DI

- **RaqNRollPlayground.WebApi**: API REST

## 🛠️ Configuração

### Pré-requisitos
- .NET 10 SDK
- PostgreSQL 12+
- Visual Studio / Rider / VS Code

### Instalação

1. Clone o repositório
2. Configure a connection string em `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=financial_control;Username=postgres;Password=postgres"
  }
}
```

3. Crie o banco de dados (opcional - EF cria automaticamente):
```bash
createdb financial_control
```

4. Execute as migrações:
```bash
dotnet ef database update --project RaqNRollPlayground.Infra --startup-project RaqNRollPlayground.WebApi
```

5. Execute a aplicação:
```bash
dotnet run --project RaqNRollPlayground.WebApi
```

## 📦 Dependências

- **Microsoft.EntityFrameworkCore** (8.0.4)
- **Microsoft.EntityFrameworkCore.Design** (8.0.4)
- **Npgsql.EntityFrameworkCore.PostgreSQL** (8.0.4)

## 🗄️ Schema do Banco de Dados

### Tabelas Criadas
- `Incomes`: Receitas do sistema
- `Outcomes`: Despesas do sistema
- `FinancialSummaries`: Sumários por período

Todas as tabelas incluem:
- `Id` (PK)
- `CreatedAt` (DateTime)
- `UpdatedAt` (DateTime)
- `IsActive` (bool)

## 🚀 Próximos Passos

1. Criar migrations iniciais
2. Implementar repositórios
3. Criar endpoints CRUD
4. Adicionar autenticação e autorização
5. Implementar validações e tratamento de erros

## 📝 Criando uma Migration

```bash
dotnet ef migrations add NomeDaMigracao --project RaqNRollPlayground.Infra --startup-project RaqNRollPlayground.WebApi
```

## 🔄 Atualizando o Banco

```bash
dotnet ef database update --project RaqNRollPlayground.Infra --startup-project RaqNRollPlayground.WebApi
```

