# 📝 Como Usar o Arquivo FinancialAPI.http

## 🎯 O que é um arquivo .http?

Um arquivo `.http` é um formato de arquivo que permite testar APIs HTTP de forma simples. É suportado nativamente por IDEs modernas como:
- ✅ **JetBrains Rider** (Incluído)
- ✅ **Visual Studio Code** (com extensão REST Client)
- ✅ **Visual Studio** (com extensão HTTP Editor)

---

## 📍 Como Usar no Rider (JetBrains)

### Passo 1: Abrir o Arquivo
1. Abra o arquivo `FinancialAPI.http` no Rider
2. O arquivo aparecerá com formatação especial

### Passo 2: Executar uma Requisição
- **Clique no ícone ▶️ verde** à esquerda de cada requisição
- Ou use o atalho: `Ctrl+Alt+E` (Windows/Linux) ou `Cmd+Alt+E` (Mac)

### Passo 3: Ver a Resposta
A resposta aparecerá em um painel à direita com:
- ✅ Status code
- ✅ Response headers
- ✅ Response body (JSON formatado)

---

## 📍 Como Usar no Visual Studio Code

### Passo 1: Instalar Extensão
1. Abra o VSCode
2. Vá para Extensions (`Ctrl+Shift+X`)
3. Procure por "REST Client"
4. Instale a extensão por **Huachao Mao**

### Passo 2: Abrir o Arquivo
1. Abra `FinancialAPI.http`
2. Você verá "Send Request" acima de cada requisição

### Passo 3: Executar
- Clique em "Send Request"
- Ou use `Ctrl+Alt+E`

---

## 📋 Estrutura do Arquivo

O arquivo contém **4 seções principais**:

### Seção 1: Endpoints Principais (4 requisições)
```http
GET http://localhost:5000/api/financialsummary/outcomes/2026-04
GET http://localhost:5000/api/financialsummary/incomes/2026-04
GET http://localhost:5000/api/financialsummary/report/2026-04
GET http://localhost:5000/api/financialsummary/current-month
```

### Seção 2: Testes com Diferentes Períodos
```http
GET http://localhost:5000/api/financialsummary/outcomes/2026-03
GET http://localhost:5000/api/financialsummary/incomes/2026-05
```

### Seção 3: Testes de Erro
```http
GET http://localhost:5000/api/financialsummary/outcomes/invalid
GET http://localhost:5000/api/financialsummary/outcomes/04-2026
```

### Seção 4: Exemplos com Variáveis (Comentado)
Descomente para usar variáveis reutilizáveis

---

## 🚀 Teste Rápido (3 Passos)

### Passo 1: Iniciar a API
```bash
cd D:\Projects\Dotnet\RaqNRollPlayground
dotnet run --project RaqNRollPlayground.WebApi
```

### Passo 2: Abrir o Arquivo no Rider/VSCode
- Arquivo: `FinancialAPI.http`

### Passo 3: Clicar em "Send Request"
- Clique no ícone ▶️ (Rider) ou no texto "Send Request" (VSCode)
- Veja a resposta JSON

---

## 📊 Exemplos de Saída

### Requisição 1: Despesas
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
    }
  ]
}
```

### Requisição 2: Receitas
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
      "percentage": 66.225...
    }
  ]
}
```

### Requisição 3: Relatório Completo
```json
{
  "summary": { ... },
  "outcomeSummary": { ... },
  "incomeSummary": { ... }
}
```

### Requisição 4: Mês Atual
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

---

## 🔧 Usando Variáveis

### Descomente a Última Seção
No arquivo `.http`, descomente estas linhas:

```http
@baseUrl = http://localhost:5000
@period = 2026-04

GET {{baseUrl}}/api/financialsummary/outcomes/{{period}}
```

### Benefícios
- ✅ Reutilizar URLs
- ✅ Mudar o período em um lugar
- ✅ Mais fácil de manter

### Exemplo de Uso
```http
@baseUrl = http://localhost:5000
@period = 2026-04
@contentType = application/json

GET {{baseUrl}}/api/financialsummary/report/{{period}}
Accept: {{contentType}}
```

---

## 🎯 Dicas e Truques

### 1️⃣ Adicionar Headers Personalizados
```http
GET http://localhost:5000/api/financialsummary/outcomes/2026-04
Accept: application/json
Authorization: Bearer seu-token-aqui
X-Custom-Header: valor
```

### 2️⃣ Enviar Dados no POST (Quando Implementado)
```http
POST http://localhost:5000/api/incomes
Content-Type: application/json

{
  "description": "Freelance",
  "amount": 500,
  "category": "Freelance",
  "incomeDate": "2026-04-20"
}
```

### 3️⃣ Usar Diferentes Períodos
```http
# Abril
GET http://localhost:5000/api/financialsummary/outcomes/2026-04

###

# Maio
GET http://localhost:5000/api/financialsummary/outcomes/2026-05

###

# Junho
GET http://localhost:5000/api/financialsummary/outcomes/2026-06
```

### 4️⃣ Testar Erros
```http
# Período inválido (deve retornar 400)
GET http://localhost:5000/api/financialsummary/outcomes/invalid

###

# Formato errado (deve retornar 400)
GET http://localhost:5000/api/financialsummary/outcomes/04-2026
```

---

## 📱 Diferenciar no Rider vs VSCode

| Recurso | Rider | VSCode |
|---------|-------|--------|
| Native Support | ✅ Integrado | ❌ Requer extensão |
| Visualização | ✅ Painel integrado | ✅ Aba lateral |
| Variáveis | ✅ Sim | ✅ Sim |
| Histórico | ✅ Sim | ✅ Sim |
| Facilidade | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ |

---

## 🐛 Solução de Problemas

### Erro: "Connection refused"
**Problema**: API não está rodando
**Solução**:
```bash
dotnet run --project RaqNRollPlayground.WebApi
```

### Erro: "404 Not Found"
**Problema**: URL incorreta
**Solução**: Verifique se:
- A URL está correta
- O período está no formato `yyyy-MM`
- A API está rodando

### Erro: "Bad Request"
**Problema**: Período inválido
**Solução**:
- Use formato `2026-04` (não `04-2026`)
- Use datas válidas

### VSCode: Sem "Send Request"
**Problema**: Extensão REST Client não instalada
**Solução**:
1. `Ctrl+Shift+X`
2. Procure "REST Client"
3. Instale por Huachao Mao

---

## 💡 Casos de Uso

### Use Case 1: Verificar Saldo do Mês
```http
GET http://localhost:5000/api/financialsummary/current-month
```
Resposta: Saldo atual em tempo real

### Use Case 2: Análise de Despesas
```http
GET http://localhost:5000/api/financialsummary/outcomes/2026-04
```
Resposta: Onde o dinheiro está sendo gasto

### Use Case 3: Análise de Receitas
```http
GET http://localhost:5000/api/financialsummary/incomes/2026-04
```
Resposta: Fontes de renda

### Use Case 4: Relatório Completo
```http
GET http://localhost:5000/api/financialsummary/report/2026-04
```
Resposta: Visão 360° financeira

---

## 📝 Cheat Sheet

```
### Despesas de abril
GET http://localhost:5000/api/financialsummary/outcomes/2026-04

### Receitas de abril
GET http://localhost:5000/api/financialsummary/incomes/2026-04

### Relatório completo
GET http://localhost:5000/api/financialsummary/report/2026-04

### Mês atual
GET http://localhost:5000/api/financialsummary/current-month
```

---

## ✅ Checklist

- [ ] Arquivo `FinancialAPI.http` aberto
- [ ] API rodando (`dotnet run`)
- [ ] Primeira requisição executada
- [ ] Resposta JSON recebida
- [ ] Variáveis funcionando (opcional)
- [ ] Todos os 4 endpoints testados

---

**Pronto para testar! Execute a primeira requisição e veja a mágica acontecer ✨**

