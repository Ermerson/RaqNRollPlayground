-- Script de dados de exemplo para a base de dados financial_control
-- Execute este script se preferir popular os dados manualmente via pgAdmin ou psql

-- Limpar dados anteriores (opcional)
-- DELETE FROM "FinancialSummaries";
-- DELETE FROM "Outcomes";
-- DELETE FROM "Incomes";

-- ===== RECEITAS (INCOMES) =====

INSERT INTO "Incomes" 
  ("Description", "Amount", "IncomeDate", "Category", "Notes", "CreatedAt", "UpdatedAt", "IsActive")
VALUES
  ('Salário Mensal', 5000.00, '2026-04-01T00:00:00Z', 'Salário', 'Salário referente ao mês de abril', NOW(), NOW(), true),
  ('Freelance - Projeto Web', 1500.00, '2026-04-05T00:00:00Z', 'Freelance', 'Trabalho de desenvolvimento web', NOW(), NOW(), true),
  ('Rendimento de Investimento', 250.00, '2026-04-10T00:00:00Z', 'Investimento', 'Rendimento mensal da aplicação', NOW(), NOW(), true),
  ('Bônus', 800.00, '2026-04-15T00:00:00Z', 'Bônus', 'Bônus de desempenho', NOW(), NOW(), true);

-- ===== DESPESAS (OUTCOMES) =====

INSERT INTO "Outcomes" 
  ("Description", "Amount", "OutcomeDate", "Category", "Notes", "CreatedAt", "UpdatedAt", "IsActive")
VALUES
  ('Aluguel do Apartamento', 1500.00, '2026-04-03T00:00:00Z', 'Moradia', 'Aluguel referente a abril', NOW(), NOW(), true),
  ('Supermercado', 450.00, '2026-04-02T00:00:00Z', 'Alimentação', 'Compras no supermercado', NOW(), NOW(), true),
  ('Passagem de Ônibus', 150.00, '2026-04-04T00:00:00Z', 'Transporte', 'Recarreg do cartão de transporte', NOW(), NOW(), true),
  ('Conta de Energia', 320.00, '2026-04-06T00:00:00Z', 'Utilitários', 'Fatura de energia elétrica', NOW(), NOW(), true),
  ('Internet', 99.90, '2026-04-06T00:00:00Z', 'Utilitários', 'Conta de internet', NOW(), NOW(), true),
  ('Restaurante', 85.00, '2026-04-07T00:00:00Z', 'Alimentação', 'Almoço com amigos', NOW(), NOW(), true),
  ('Cinema', 60.00, '2026-04-12T00:00:00Z', 'Lazer', 'Sessão de cinema', NOW(), NOW(), true),
  ('Plano de Streaming', 29.90, '2026-04-01T00:00:00Z', 'Lazer', 'Assinatura mensal', NOW(), NOW(), true);

-- ===== SUMÁRIO FINANCEIRO (FINANCIAL SUMMARIES) =====

INSERT INTO "FinancialSummaries"
  ("Period", "TotalIncome", "TotalOutcome", "NetBalance", "StartDate", "EndDate", "CreatedAt", "UpdatedAt", "IsActive")
VALUES
  ('2026-04', 7550.00, 2694.80, 4855.20, '2026-04-01T00:00:00Z', '2026-04-30T23:59:59Z', NOW(), NOW(), true);

-- ===== VERIFICAR OS DADOS =====

SELECT '=== RECEITAS ===' as "";
SELECT "Id", "Description", "Amount", "Category", "IncomeDate" FROM "Incomes" ORDER BY "IncomeDate";

SELECT '' as "";
SELECT '=== DESPESAS ===' as "";
SELECT "Id", "Description", "Amount", "Category", "OutcomeDate" FROM "Outcomes" ORDER BY "OutcomeDate";

SELECT '' as "";
SELECT '=== SUMÁRIO ===' as "";
SELECT "Period", "TotalIncome", "TotalOutcome", "NetBalance" FROM "FinancialSummaries";

SELECT '' as "";
SELECT '=== ESTATÍSTICAS ===' as "";
SELECT 
  'Total de Receitas' as "Descrição",
  (SELECT SUM("Amount") FROM "Incomes" WHERE "IsActive" = true) as "Valor"
UNION ALL
SELECT 
  'Total de Despesas',
  (SELECT SUM("Amount") FROM "Outcomes" WHERE "IsActive" = true)
UNION ALL
SELECT 
  'Saldo Líquido',
  (SELECT SUM("Amount") FROM "Incomes" WHERE "IsActive" = true) - (SELECT SUM("Amount") FROM "Outcomes" WHERE "IsActive" = true);

