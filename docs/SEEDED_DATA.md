# 📊 Seeding de Dados - Registros Aplicados

## ✅ Dados Inseridos com Sucesso!

O seeding foi executado automaticamente ao iniciar a aplicação e criou os seguintes registros:

## 💰 Receitas (Incomes) - Total: R$ 7.550,00

| ID | Descrição | Valor | Categoria | Data | Notas |
|:--:|-----------|------:|-----------|------|-------|
| 1 | Salário Mensal | R$ 5.000,00 | Salário | 01/04/2026 | Salário referente ao mês de abril |
| 2 | Freelance - Projeto Web | R$ 1.500,00 | Freelance | 05/04/2026 | Trabalho de desenvolvimento web |
| 3 | Rendimento de Investimento | R$ 250,00 | Investimento | 10/04/2026 | Rendimento mensal da aplicação |
| 4 | Bônus | R$ 800,00 | Bônus | 15/04/2026 | Bônus de desempenho |

## 💸 Despesas (Outcomes) - Total: R$ 2.694,80

| ID | Descrição | Valor | Categoria | Data | Notas |
|:--:|-----------|------:|-----------|------|-------|
| 1 | Aluguel do Apartamento | R$ 1.500,00 | Moradia | 03/04/2026 | Aluguel referente a abril |
| 2 | Supermercado | R$ 450,00 | Alimentação | 02/04/2026 | Compras no supermercado |
| 3 | Passagem de Ônibus | R$ 150,00 | Transporte | 04/04/2026 | Recarga do cartão de transporte |
| 4 | Conta de Energia | R$ 320,00 | Utilitários | 06/04/2026 | Fatura de energia elétrica |
| 5 | Internet | R$ 99,90 | Utilitários | 06/04/2026 | Conta de internet |
| 6 | Restaurante | R$ 85,00 | Alimentação | 07/04/2026 | Almoço com amigos |
| 7 | Cinema | R$ 60,00 | Lazer | 12/04/2026 | Sessão de cinema |
| 8 | Plano de Streaming | R$ 29,90 | Lazer | 01/04/2026 | Assinatura mensal |

## 📈 Sumário Financeiro

| Período | Total Receitas | Total Despesas | Saldo Líquido |
|---------|---------------:|---------------:|---------------:|
| 2026-04 | R$ 7.550,00 | R$ 2.694,80 | **R$ 4.855,20** ✅ |

## 📋 Resumo por Categoria

### Receitas
- **Salário**: R$ 5.000,00 (66,2%)
- **Freelance**: R$ 1.500,00 (19,9%)
- **Bônus**: R$ 800,00 (10,6%)
- **Investimento**: R$ 250,00 (3,3%)

### Despesas
- **Moradia**: R$ 1.500,00 (55,7%)
- **Alimentação**: R$ 535,00 (19,9%)
- **Utilitários**: R$ 419,90 (15,6%)
- **Lazer**: R$ 89,90 (3,3%)
- **Transporte**: R$ 150,00 (5,6%)

## 🔍 Consultar os Dados

### Via SQL (pgAdmin ou psql)

```sql
-- Ver todas as receitas
SELECT * FROM "Incomes" ORDER BY "IncomeDate";

-- Ver todas as despesas
SELECT * FROM "Outcomes" ORDER BY "OutcomeDate";

-- Ver sumários
SELECT * FROM "FinancialSummaries";

-- Estatísticas por categoria (Receitas)
SELECT "Category", SUM("Amount") as "Total"
FROM "Incomes"
WHERE "IsActive" = true
GROUP BY "Category"
ORDER BY "Total" DESC;

-- Estatísticas por categoria (Despesas)
SELECT "Category", SUM("Amount") as "Total"
FROM "Outcomes"
WHERE "IsActive" = true
GROUP BY "Category"
ORDER BY "Total" DESC;

-- Relatório completo
SELECT 
  (SELECT SUM("Amount") FROM "Incomes" WHERE "IsActive" = true) as "Total_Receitas",
  (SELECT SUM("Amount") FROM "Outcomes" WHERE "IsActive" = true) as "Total_Despesas",
  (SELECT SUM("Amount") FROM "Incomes" WHERE "IsActive" = true) - 
  (SELECT SUM("Amount") FROM "Outcomes" WHERE "IsActive" = true) as "Saldo_Liquido";
```

### Via Aplicação .NET

```csharp
// Injetar FinancialContext
var incomes = context.Incomes.ToList();
var outcomes = context.Outcomes.ToList();
var summaries = context.FinancialSummaries.ToList();
```

## 📝 Arquivo SQL Manual

Você também pode executar manualmente os dados usando o arquivo `seed-data.sql`:

```bash
# Via Docker
docker exec -it financial_control_postgres psql -U postgres -d financial_control < seed-data.sql

# Via linha de comando local
psql -U postgres -d financial_control -f seed-data.sql
```

## 🔄 Reimportar os Dados

Se os dados já estão no banco e você quer reimportá-los, execute:

```bash
# Via SQL - Limpar dados (descomente as linhas no seed-data.sql)
DELETE FROM "FinancialSummaries";
DELETE FROM "Outcomes";
DELETE FROM "Incomes";
```

Depois reinicie a aplicação para reexecutar o seeding.

## 📌 Notas Importantes

- ✅ O seeding é **idempotente** - se os dados já existem, não são duplicados
- ✅ Todos os registros têm `IsActive = true`
- ✅ As datas são em **UTC (Coordinated Universal Time)**
- ✅ Os valores são em **Decimal** para precisão monetária
- ✅ O saldo é **positivo**: receitas > despesas (R$ 4.855,20)

## 🎯 Próximos Passos

1. ✅ Dados seedados
2. ⏭️ Criar repositórios para as entidades
3. ⏭️ Implementar endpoints CRUD
4. ⏭️ Adicionar filtros e paginação
5. ⏭️ Criar relatórios financeiros

