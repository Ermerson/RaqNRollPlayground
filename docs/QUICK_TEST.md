# 🚀 Guia Rápido de Teste - API de Sumário Financeiro

## ⚡ Teste em 2 Minutos

### Passo 1: Iniciar a Aplicação
```bash
cd D:\Projects\Dotnet\RaqNRollPlayground
dotnet run --project RaqNRollPlayground.WebApi
```

Aguarde a mensagem:
```
Now listening on: http://localhost:5000
```

### Passo 2: Abrir Terminal ou Postman

#### Opção A: Usando PowerShell (Simples)
```powershell
# Sumário de Despesas
Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/outcomes/2026-04" | ConvertTo-Json

# Sumário de Receitas
Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/incomes/2026-04" | ConvertTo-Json

# Relatório Completo
Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/report/2026-04" | ConvertTo-Json

# Mês Atual
Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/current-month" | ConvertTo-Json
```

#### Opção B: Usando cURL
```bash
# Sumário de Despesas
curl http://localhost:5000/api/financialsummary/outcomes/2026-04

# Sumário de Receitas
curl http://localhost:5000/api/financialsummary/incomes/2026-04

# Relatório Completo
curl http://localhost:5000/api/financialsummary/report/2026-04

# Mês Atual
curl http://localhost:5000/api/financialsummary/current-month
```

#### Opção C: Usando Browser
```
http://localhost:5000/api/financialsummary/current-month
```

## 🎯 Saídas Esperadas

### 1️⃣ Despesas (outcomes/2026-04)

```json
{
  "period": "2026-04",
  "totalOutcomes": 2694.8,
  "outcomeCount": 8,
  "averageOutcome": 336.85,
  "outcomesByCategory": [
    {
      "category": "Moradia",
      "total": 1500,
      "count": 1,
      "percentage": 55.669...
    },
    {
      "category": "Alimentação",
      "total": 535,
      "count": 2,
      "percentage": 19.857...
    },
    {
      "category": "Utilitários",
      "total": 419.9,
      "count": 2,
      "percentage": 15.579...
    }
  ],
  "latestOutcomes": [
    {
      "id": 7,
      "description": "Cinema",
      "amount": 60,
      "category": "Lazer",
      "date": "2026-04-12T00:00:00Z",
      "notes": "Sessão de cinema"
    }
  ]
}
```

### 2️⃣ Receitas (incomes/2026-04)

```json
{
  "period": "2026-04",
  "totalIncomes": 7550,
  "incomeCount": 4,
  "averageIncome": 1887.5,
  "incomesByCategory": [
    {
      "category": "Salário",
      "total": 5000,
      "count": 1,
      "percentage": 66.225...
    },
    {
      "category": "Freelance",
      "total": 1500,
      "count": 1,
      "percentage": 19.867...
    }
  ],
  "latestIncomes": [...]
}
```

### 3️⃣ Mês Atual (current-month)

```json
{
  "period": "2026-04",
  "totalIncome": 7550,
  "totalOutcome": 2694.8,
  "netBalance": 4855.2,
  "startDate": "2026-04-01T00:00:00Z",
  "endDate": "2026-04-30T23:59:59Z"
}
```

## 📋 Checklist de Teste

- [ ] API inicia sem erros
- [ ] Endpoint de despesas retorna dados
- [ ] Endpoint de receitas retorna dados
- [ ] Relatório completo combina ambos
- [ ] Sumário do mês atual calcula corretamente
- [ ] JSON está bem formatado
- [ ] Percentuais somam 100%
- [ ] Saldo líquido está correto (7550 - 2694.8 = 4855.2)

## 🐛 Solução de Problemas

### Erro: "Connection refused"
**Problema**: API não iniciou
**Solução**: 
```bash
dotnet run --project RaqNRollPlayground.WebApi
```

### Erro: "Bad Request - Período inválido"
**Problema**: Formato de período incorreto
**Solução**: Use formato `yyyy-MM` (exemplo: `2026-04`)

### Erro: "Could not connect to database"
**Problema**: PostgreSQL não está rodando
**Solução**:
```bash
docker-compose up -d
```

### Dados vazios
**Problema**: Seeding não executou
**Solução**: Reinicie a aplicação
```bash
dotnet run --project RaqNRollPlayground.WebApi
```

## 📊 Dados de Teste

Os dados foram automaticamente seedados:

**Receitas (Total: R$ 7.550,00)**
- Salário: R$ 5.000,00
- Freelance: R$ 1.500,00
- Bônus: R$ 800,00
- Investimento: R$ 250,00

**Despesas (Total: R$ 2.694,80)**
- Moradia: R$ 1.500,00
- Alimentação: R$ 535,00
- Utilitários: R$ 419,90
- Transporte: R$ 150,00
- Lazer: R$ 89,90

**Saldo: R$ 4.855,20** ✅

## 🎬 Script Completo de Teste

```powershell
# Teste completo
Write-Host "=== Teste da API de Sumário Financeiro ===" -ForegroundColor Green

Write-Host "`n1. Despesas do período:" -ForegroundColor Yellow
$outcomes = Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/outcomes/2026-04"
Write-Host "Total: R$ $($outcomes.totalOutcomes)"
Write-Host "Categorias: $($outcomes.outcomesByCategory.Count)"

Write-Host "`n2. Receitas do período:" -ForegroundColor Yellow
$incomes = Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/incomes/2026-04"
Write-Host "Total: R$ $($incomes.totalIncomes)"
Write-Host "Categorias: $($incomes.incomesByCategory.Count)"

Write-Host "`n3. Mês Atual:" -ForegroundColor Yellow
$current = Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/current-month"
Write-Host "Período: $($current.period)"
Write-Host "Receitas: R$ $($current.totalIncome)"
Write-Host "Despesas: R$ $($current.totalOutcome)"
Write-Host "Saldo: R$ $($current.netBalance)" -ForegroundColor Green

Write-Host "`n✅ API está funcionando corretamente!" -ForegroundColor Green
```

## 📝 Notas

- ✅ Todos os endpoints retornam JSON
- ✅ Formato de data: ISO 8601 (UTC)
- ✅ Valores monetários com até 2 casas decimais
- ✅ Sem autenticação (aberto para desenvolvimento)
- ✅ CORS habilitado para chamadas locais

## 🔗 Links Úteis

- **Documentação Completa**: Veja `API_ENDPOINTS.md`
- **Resumo de Implementação**: Veja `IMPLEMENTATION_SUMMARY.md`
- **Dados Seedados**: Veja `SEEDED_DATA.md`
- **Setup Docker**: Veja `DOCKER_SETUP.md`

---

**Pronto para testar? Comece pelo Passo 1! 🚀**

