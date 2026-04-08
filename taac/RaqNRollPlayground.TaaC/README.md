# 🧪 TaaC - Test as Code - Financial API Smoke Tests

## 📋 Visão Geral

Este projeto contém testes de smoke test para a API Financial Control usando:
- **ReqNroll** (BDD Framework)
- **xUnit** (Test Framework)
- **Gherkin** (.feature files)

## 🎯 Testes Inclusos

### Smoke Tests
- ✅ `Get current month summary` - Testa endpoint do sumário do mês atual
- ✅ `Get outcome summary for a specific period` - Testa endpoint de despesas
- ✅ `Get income summary for a specific period` - Testa endpoint de receitas  
- ✅ `Get financial report for a specific period` - Testa relatório completo
- ✅ `Test invalid period format` - Testa validação de entrada
- ✅ `Verify API is accessible` - Testa saúde geral da API

## 🚀 Como Executar

### Pré-requisitos
1. A API está rodando em `http://localhost:8080`
2. .NET 10.0 SDK instalado
3. Projeto compilado

### Executar todos os testes

```bash
# Navegar para a pasta do projeto
cd taac/RaqNRollPlayground.TaaC

# Executar com dotnet test
dotnet test

# Ou com filtro específico
dotnet test --filter "@smoketest"
```

### Executar com Visual Studio

```bash
# Abrir Test Explorer
Test > Test Explorer

# Ou apertar Ctrl+E, T

# Executar testes por tag ou nome
```

### Executar com linha de comando (ReqNroll)

```bash
# Instalar ReqNroll CLI (se não tiver)
dotnet tool install SpecFlow.Plus.LivingDoc.CLI

# Gerar relatório
cd taac/RaqNRollPlayground.TaaC
livingdoc test-assembly bin/Debug/net10.0/RaqNRollPlayground.TaaC.dll -t bin/Debug/net10.0/RaqNRollPlayground.TaaC.dll
```

## 📁 Estrutura do Projeto

```
taac/RaqNRollPlayground.TaaC/
├── Features/
│   ├── FinancialAPI.feature      ← Cenários de teste (Gherkin)
│   └── Calculator.feature         ← Exemplo de teste
├── StepDefinitions/
│   ├── FinancialApiStepDefinitions.cs ← Step definitions para API
│   └── CalculatorStepDefinitions.cs   ← Exemplo
├── Helpers/
│   └── ApiClient.cs              ← Helper para requisições HTTP
├── Hooks/
│   └── Hooks.cs                  ← Setup/Teardown dos testes
├── RaqNRollPlayground.TaaC.csproj
├── reqnroll.json                 ← Configuração do ReqNroll
└── README.md                      ← Este arquivo
```

## 🔧 Componentes

### 1. **FinancialAPI.feature**
Define os cenários de teste em linguagem Gherkin (legível por humanos):
```gherkin
Scenario: Get current month summary
  When I call the endpoint "GET /api/FinancialSummary/current-month"
  Then the response status should be 200
  And the response should contain a valid JSON
```

### 2. **FinancialApiStepDefinitions.cs**
Implementa os steps em C#:
```csharp
[When("I call the endpoint {string}")]
public async Task WhenICallTheEndpoint(string endpoint)
{
    // Implementação do teste
}
```

### 3. **ApiClient.cs**
Helper para fazer requisições HTTP:
```csharp
var response = await apiClient.GetAsync("/api/FinancialSummary/current-month");
```

### 4. **Hooks.cs**
Setup e teardown automático dos testes:
```csharp
[BeforeScenario]
public void BeforeScenario()
{
    // Executa antes de cada cenário
}
```

## 📊 Endpoints Testados

| Endpoint | Método | Descrição |
|----------|--------|-----------|
| `/api/FinancialSummary/current-month` | GET | Sumário do mês atual |
| `/api/FinancialSummary/outcomes/{period}` | GET | Despesas de um período |
| `/api/FinancialSummary/incomes/{period}` | GET | Receitas de um período |
| `/api/FinancialSummary/report/{period}` | GET | Relatório completo |

## 🏷️ Tags

Os testes estão marcados com tags para fácil filtragem:

- `@smoketest` - Testes de smoke test
- `@api` - Testes de API
- `@health` - Testes de saúde da API

```bash
# Executar apenas smoke tests
dotnet test --filter "@smoketest"

# Executar apenas testes de API
dotnet test --filter "@api"
```

## 📈 Estrutura de Teste

### Arrange → Act → Assert
```
Background:
  Given the API is running at "http://localhost:8080"    # Arrange
  And the current period is "2026-04"

Scenario:
  When I call the endpoint "GET /api/FinancialSummary/outcomes/2026-04"  # Act
  Then the response status should be 200                                 # Assert
  And the response should contain a valid JSON                          # Assert
```

## 🐛 Troubleshooting

### ❌ Erro: "Cannot connect to API"
- Verifique se a API está rodando em `http://localhost:8080`
- Execute: `docker-compose up -d` na pasta raiz

### ❌ Erro: "Connection refused"
- Aguarde alguns segundos para a API iniciar
- Verifique se a porta 8080 está disponível

### ❌ Erro: "Test failed - Invalid JSON"
- Verifique se a API retornou um JSON válido
- Verifique os logs da API: `docker-compose logs -f api`

## 📝 Adicionar Novos Testes

### 1. Criar um novo Feature
```gherkin
Feature: New Feature Name

@smoketest
Scenario: New scenario
  Given precondition
  When action
  Then assertion
```

### 2. Implementar Step Definitions
```csharp
[Given("precondition")]
public void GivenPrecondition()
{
    // Implementação
}
```

### 3. Executar os testes
```bash
dotnet test
```

## 📚 Recursos

- [ReqNroll Documentation](https://go.reqnroll.net/)
- [Gherkin Syntax](https://cucumber.io/docs/gherkin/)
- [xUnit.net](https://xunit.net/)
- [HTTP Testing Best Practices](https://restfulapi.net/testing/)

## 🎯 Próximos Passos

1. ✅ Executar testes básicos
2. ✅ Verificar se todos os testes passam
3. ⏳ Adicionar testes de validação de dados
4. ⏳ Adicionar testes de performance
5. ⏳ Integrar com CI/CD pipeline

## 📊 Relatórios

Os testes geram relatórios em HTML:
```
bin/Debug/net10.0/Reports/
├── LivingDoc.html
└── index.html
```

## 🤝 Contribuindo

Para adicionar novos testes:
1. Crie um novo arquivo `.feature` em `Features/`
2. Implemente os steps em `StepDefinitions/`
3. Execute `dotnet test` para validar
4. Commit e push

## 📞 Suporte

Se encontrar problemas:
1. Verifique se a API está rodando
2. Verifique os logs: `docker-compose logs`
3. Execute `dotnet restore` para restaurar dependências
4. Limpe e reconstrua: `dotnet clean && dotnet build`

---

**Happy Testing! 🚀**

