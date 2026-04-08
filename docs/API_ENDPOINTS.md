# 📊 API de Sumário Financeiro

## 🎯 Endpoints Disponíveis

A API fornece endpoints para obter sumários e relatórios financeiros em formato JSON.

### Base URL
```
http://localhost:5000/api/financialsummary
```

---

## 1. Obter Sumário de Despesas

**Endpoint**: `GET /api/financialsummary/outcomes/{period}`

**Descrição**: Retorna um relatório detalhado de despesas para um período específico

**Parâmetros**:
- `period` (string, required): Período no formato `yyyy-MM` (exemplo: `2026-04`)

**Exemplo de Requisição**:
```bash
curl -X GET "http://localhost:5000/api/financialsummary/outcomes/2026-04"
```

**Exemplo de Resposta (200 OK)**:
```json
{
  "period": "2026-04",
  "totalOutcomes": 2694.80,
  "outcomeCount": 8,
  "averageOutcome": 336.85,
  "outcomesByCategory": [
    {
      "category": "Moradia",
      "total": 1500.00,
      "count": 1,
      "percentage": 55.67
    },
    {
      "category": "Alimentação",
      "total": 535.00,
      "count": 2,
      "percentage": 19.86
    },
    {
      "category": "Utilitários",
      "total": 419.90,
      "count": 2,
      "percentage": 15.58
    },
    {
      "category": "Transporte",
      "total": 150.00,
      "count": 1,
      "percentage": 5.57
    },
    {
      "category": "Lazer",
      "total": 89.90,
      "count": 2,
      "percentage": 3.34
    }
  ],
  "latestOutcomes": [
    {
      "id": 4,
      "description": "Conta de Energia",
      "amount": 320.00,
      "category": "Utilitários",
      "date": "2026-04-06T00:00:00Z",
      "notes": "Fatura de energia elétrica"
    },
    {
      "id": 1,
      "description": "Aluguel do Apartamento",
      "amount": 1500.00,
      "category": "Moradia",
      "date": "2026-04-03T00:00:00Z",
      "notes": "Aluguel referente a abril"
    }
  ]
}
```

---

## 2. Obter Sumário de Receitas

**Endpoint**: `GET /api/financialsummary/incomes/{period}`

**Descrição**: Retorna um relatório detalhado de receitas para um período específico

**Parâmetros**:
- `period` (string, required): Período no formato `yyyy-MM` (exemplo: `2026-04`)

**Exemplo de Requisição**:
```bash
curl -X GET "http://localhost:5000/api/financialsummary/incomes/2026-04"
```

**Exemplo de Resposta (200 OK)**:
```json
{
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
    },
    {
      "category": "Freelance",
      "total": 1500.00,
      "count": 1,
      "percentage": 19.87
    },
    {
      "category": "Bônus",
      "total": 800.00,
      "count": 1,
      "percentage": 10.60
    },
    {
      "category": "Investimento",
      "total": 250.00,
      "count": 1,
      "percentage": 3.31
    }
  ],
  "latestIncomes": [
    {
      "id": 4,
      "description": "Bônus",
      "amount": 800.00,
      "category": "Bônus",
      "date": "2026-04-15T00:00:00Z",
      "notes": "Bônus de desempenho"
    },
    {
      "id": 3,
      "description": "Rendimento de Investimento",
      "amount": 250.00,
      "category": "Investimento",
      "date": "2026-04-10T00:00:00Z",
      "notes": "Rendimento mensal da aplicação"
    }
  ]
}
```

---

## 3. Obter Relatório Financeiro Completo

**Endpoint**: `GET /api/financialsummary/report/{period}`

**Descrição**: Retorna um relatório completo com receitas, despesas e sumário

**Parâmetros**:
- `period` (string, required): Período no formato `yyyy-MM` (exemplo: `2026-04`)

**Exemplo de Requisição**:
```bash
curl -X GET "http://localhost:5000/api/financialsummary/report/2026-04"
```

**Exemplo de Resposta (200 OK)**:
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
        "percentage": 55.67
      }
    ],
    "latestOutcomes": []
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
    ],
    "latestIncomes": []
  }
}
```

---

## 4. Obter Sumário do Mês Atual

**Endpoint**: `GET /api/financialsummary/current-month`

**Descrição**: Retorna o sumário financeiro do mês atual

**Parâmetros**: Nenhum

**Exemplo de Requisição**:
```bash
curl -X GET "http://localhost:5000/api/financialsummary/current-month"
```

**Exemplo de Resposta (200 OK)**:
```json
{
  "period": "2026-04",
  "totalIncome": 7550.00,
  "totalOutcome": 2694.80,
  "netBalance": 4855.20,
  "startDate": "2026-04-01T00:00:00Z",
  "endDate": "2026-04-30T23:59:59Z"
}
```

---

## 📋 Estruturas de Dados

### TransactionDto
```json
{
  "id": 1,
  "description": "string",
  "amount": 0.00,
  "category": "string",
  "date": "2026-04-01T00:00:00Z",
  "notes": "string ou null"
}
```

### OutcomeByCategodyDto
```json
{
  "category": "string",
  "total": 0.00,
  "count": 0,
  "percentage": 0.00
}
```

### OutcomeSummaryReportDto
```json
{
  "period": "2026-04",
  "totalOutcomes": 0.00,
  "outcomeCount": 0,
  "averageOutcome": 0.00,
  "outcomesByCategory": [],
  "latestOutcomes": []
}
```

### IncomeSummaryReportDto
```json
{
  "period": "2026-04",
  "totalIncomes": 0.00,
  "incomeCount": 0,
  "averageIncome": 0.00,
  "incomesByCategory": [],
  "latestIncomes": []
}
```

### FinancialSummaryDto
```json
{
  "period": "2026-04",
  "totalIncome": 0.00,
  "totalOutcome": 0.00,
  "netBalance": 0.00,
  "startDate": "2026-04-01T00:00:00Z",
  "endDate": "2026-04-30T23:59:59Z"
}
```

### FinancialReportDto
```json
{
  "summary": {},
  "outcomeSummary": {},
  "incomeSummary": {}
}
```

---

## 🧪 Testando com Postman

### Importar Coleção
```
1. Abra o Postman
2. Clique em "Import" → "Paste Raw Text"
3. Cole o JSON abaixo
```

### JSON para Postman
```json
{
  "info": {
    "name": "Financial API",
    "description": "API de Sumário Financeiro"
  },
  "item": [
    {
      "name": "Despesas do Período",
      "request": {
        "method": "GET",
        "url": "http://localhost:5000/api/financialsummary/outcomes/2026-04"
      }
    },
    {
      "name": "Receitas do Período",
      "request": {
        "method": "GET",
        "url": "http://localhost:5000/api/financialsummary/incomes/2026-04"
      }
    },
    {
      "name": "Relatório Completo",
      "request": {
        "method": "GET",
        "url": "http://localhost:5000/api/financialsummary/report/2026-04"
      }
    },
    {
      "name": "Mês Atual",
      "request": {
        "method": "GET",
        "url": "http://localhost:5000/api/financialsummary/current-month"
      }
    }
  ]
}
```

---

## 🔧 Teste via cURL

```bash
# Despesas
curl -X GET "http://localhost:5000/api/financialsummary/outcomes/2026-04" | jq

# Receitas
curl -X GET "http://localhost:5000/api/financialsummary/incomes/2026-04" | jq

# Relatório Completo
curl -X GET "http://localhost:5000/api/financialsummary/report/2026-04" | jq

# Mês Atual
curl -X GET "http://localhost:5000/api/financialsummary/current-month" | jq
```

---

## ✅ Códigos de Status

| Código | Descrição |
|--------|-----------|
| 200 | OK - Requisição realizada com sucesso |
| 400 | Bad Request - Período inválido ou erro na requisição |
| 500 | Internal Server Error - Erro no servidor |

---

## 📌 Notas

- ✅ Todos os valores monetários estão em formato `Decimal` com até 2 casas decimais
- ✅ As datas estão no formato ISO 8601 (UTC)
- ✅ As categorias são agrupadas automaticamente
- ✅ Os percentuais somam 100% por grupo
- ✅ Os últimos 5 registros são retornados na lista de transações

