# Guia de Execução de Testes

## 🐳 Executar a Aplicação com Docker

### 1. Iniciar os Containers
```bash
cd D:\Projects\Dotnet\RaqNRollPlayground
docker-compose up -d
```

### 2. Verificar o Status
```bash
docker-compose ps
```

Esperado:
- ✅ `financial_control_postgres` - Healthy
- ✅ `financial_control_api` - Running

### 3. Acessar a API
- URL Base: `http://localhost:8080`
- Documentação OpenAPI: `http://localhost:8080/openapi/v1.json`

## 🧪 Testar com Arquivo HTTP

### Usando Visual Studio Code ou JetBrains IDEs

1. Abrir `FinancialAPI-Test.http`
2. Clicar em "Send Request" acima de cada endpoint

### Endpoints Disponíveis

```http
# Relatório Financeiro Completo
GET http://localhost:8080/api/FinancialSummary/report/2026-04

# Sumário de Receitas
GET http://localhost:8080/api/FinancialSummary/incomes/2026-04

# Sumário de Despesas
GET http://localhost:8080/api/FinancialSummary/outcomes/2026-04

# Sumário do Mês Atual
GET http://localhost:8080/api/FinancialSummary/current-month
```

## 🔬 Executar Testes Reqnroll (TaaC)

### 1. Pré-requisitos
- Docker containers rodando (API e PostgreSQL)
- .NET 10 SDK instalado

### 2. Executar Todos os Testes
```bash
cd taac\RaqNRollPlayground.TaaC
dotnet test
```

### 3. Executar com Filtro de Tags
```bash
# Apenas smoke tests
dotnet test --filter "Category=smoketest"

# Apenas testes de API
dotnet test --filter "Category=api"

# Apenas health checks
dotnet test --filter "Category=health"
```

### 4. Gerar Relatório de Testes
```bash
dotnet test --logger "trx;LogFileName=test-results.trx"
```

## 📊 Exemplo de Resposta da API

### GET `/api/FinancialSummary/report/2026-04`

```json
{
  "summary": {
    "period": "2026-04",
    "totalIncome": 7550.00,
    "totalOutcome": 2694.80,
    "netBalance": 4855.20,
    "startDate": "2026-04-01T00:00:00Z",
    "endDate": "2026-04-30T23:59:59Z"
  },
  "outcomeSummary": {
    "period": "2026-04",
    "totalOutcomes": 2694.80,
    "outcomeCount": 8,
    "averageOutcome": 336.85,
    "outcomesByCategory": [
      {
        "category": "Moradia",
        "total": 1500.00,
        "count": 1,
        "percentage": 55.66
      }
    ]
  },
  "incomeSummary": {
    "period": "2026-04",
    "totalIncomes": 7550.00,
    "incomeCount": 4,
    "averageIncome": 1887.50,
    "incomesByCategory": [
      {
        "category": "Salário",
        "total": 5000.00,
        "count": 1,
        "percentage": 66.23
      }
    ]
  }
}
```

## 🛑 Parar os Containers

```bash
docker-compose down
```

Para remover volumes (limpar dados):
```bash
docker-compose down -v
```

## 🔍 Troubleshooting

### Erro: "relation 'Incomes' does not exist"
**Solução**: Essa era a causa original. Com as correções implementadas, a migração será executada automaticamente na inicialização.

### Erro: "Cannot connect to PostgreSQL"
**Solução**: Verifique se o container PostgreSQL está rodando:
```bash
docker logs financial_control_postgres
```

### Erro: "API não está respondendo"
**Solução**: Verifique os logs da API:
```bash
docker logs financial_control_api
```

## 📚 Documentação Relacionada

- [RESOLUTION_SUMMARY.md](./RESOLUTION_SUMMARY.md) - Resumo das correções
- [README.md](./README.md) - Documentação geral
- [API_ENDPOINTS.md](./API_ENDPOINTS.md) - Especificação de endpoints

