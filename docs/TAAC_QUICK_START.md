# 🧪 TaaC - Executando Testes Smoke Test

## 📋 Visão Geral

Este documento explica como executar os testes de smoke test criados para a API Financial Control usando ReqNroll e BDD.

## 🎯 O que foi criado

✅ **1 arquivo Feature** - `FinancialAPI.feature`
  - 6 cenários de smoke test
  - Testes de todos os endpoints principais

✅ **Step Definitions** - `FinancialApiStepDefinitions.cs`
  - Implementação dos steps em C#
  - Integração com xUnit assertions

✅ **API Client Helper** - `ApiClient.cs`
  - Requisições HTTP simples
  - Validação de JSON
  - Tratamento de erros

✅ **Hooks** - `Hooks.cs`
  - Setup/teardown automático
  - Logging de execução

✅ **Scripts de Automação**
  - `run-taac-tests.ps1` (PowerShell - Windows)
  - `run-taac-tests.sh` (Bash - Linux/Mac)

---

## 🚀 Como Executar

### Pré-requisitos

1. **API deve estar rodando**
   ```powershell
   # Navegue para a raiz do projeto
   docker-compose up -d
   
   # Aguarde ~20 segundos
   ```

2. **.NET 10.0 SDK instalado**
   ```powershell
   dotnet --version
   ```

3. **Projeto compilado**
   ```powershell
   cd taac/RaqNRollPlayground.TaaC
   dotnet build
   ```

### Opção 1: Usar o Script PowerShell (Recomendado para Windows)

```powershell
# Na raiz do projeto
.\run-taac-tests.ps1
```

**Menu interativo com opções:**
- `all` - Executar todos os testes
- `smoketest` - Apenas smoke tests
- `api` - Apenas testes de API
- `clean` - Limpar projeto
- `build` - Compilar projeto
- `help` - Mostrar ajuda

**Exemplos:**
```powershell
.\run-taac-tests.ps1 all        # Todos os testes
.\run-taac-tests.ps1 smoketest  # Apenas smoke tests
.\run-taac-tests.ps1 api        # Apenas API tests
```

### Opção 2: Usar o Script Bash (Linux/Mac)

```bash
./run-taac-tests.sh
```

Mesmas opções do PowerShell.

### Opção 3: Comando Direto com dotnet test

```powershell
cd taac/RaqNRollPlayground.TaaC

# Todos os testes
dotnet test

# Apenas smoke tests
dotnet test --filter "@smoketest"

# Apenas testes de API
dotnet test --filter "@api"

# Com output verboso
dotnet test --verbosity detailed

# Sem paralelização
dotnet test --parallel:none
```

### Opção 4: Usar Visual Studio

1. Abrir `RaqNRollPlayground.sln`
2. Menu: `Test` → `Test Explorer` (ou `Ctrl+E, T`)
3. Clicar em cada teste ou executar todos
4. Filtrar por tags: `@smoketest` ou `@api`

---

## 📊 Executar Testes Específicos

### Por Tag
```powershell
# Apenas smoke tests
dotnet test --filter "@smoketest"

# Apenas testes de API
dotnet test --filter "@api"

# Apenas testes de saúde
dotnet test --filter "@health"
```

### Por Nome do Cenário
```powershell
# Teste específico
dotnet test --filter "GetCurrentMonth"

# Contém texto
dotnet test --filter "Current"
```

### Por Nome da Feature
```powershell
dotnet test --filter "FinancialAPI"
```

---

## 📈 Saída dos Testes

Ao executar os testes, você verá:

```
✅ COMEÇANDO
  🧪 Iniciando cenário: Get current month summary
  📊 Executando Smoke Test
  📨 Quando: I call the endpoint "GET /api/FinancialSummary/current-month"
  ✓ Então: the response status should be 200
  ✓ E: the response should contain a valid JSON
  ✅ PASSOU

❌ SE FALHAR
  ❌ FALHOU
  Erro: Status esperado 200, mas recebeu 0
```

---

## 🔍 Verificação de Pré-requisitos

Antes de executar, verifique:

### API está rodando?
```powershell
# Teste de conectividade
curl http://localhost:8080

# Ou use PowerShell
Invoke-WebRequest -Uri http://localhost:8080 -ErrorAction SilentlyContinue
```

### Projeto está compilado?
```powershell
cd taac/RaqNRollPlayground.TaaC
ls bin/Debug/net10.0/RaqNRollPlayground.TaaC.dll
```

### ReqNroll funcionando?
```powershell
dotnet test --verbosity detailed 2>&1 | Select-String "Reqnroll"
```

---

## 📝 Logs e Debugging

### Ver logs verbosos
```powershell
dotnet test --verbosity detailed
```

### Ver apenas falhas
```powershell
dotnet test --verbosity quiet
```

### Logs da API
```powershell
# Em outro terminal
docker-compose logs -f api
```

### Logs do PostgreSQL
```powershell
docker-compose logs -f postgres
```

---

## 🐛 Troubleshooting

### ❌ Erro: "Cannot connect to API"
```powershell
# Verifique se a API está rodando
docker-compose ps

# Se não estiver, inicie
docker-compose up -d

# Aguarde 20 segundos e tente novamente
Start-Sleep -Seconds 20
dotnet test
```

### ❌ Erro: "Connection refused"
```powershell
# A API não respondeu a tempo
# Verifique se está pronta
curl http://localhost:8080

# Verifique os logs
docker-compose logs api
```

### ❌ Erro: "Test failed - Invalid JSON"
```powershell
# A resposta não é um JSON válido
# Verifique os logs da API
docker-compose logs -f api

# Teste o endpoint manualmente
curl http://localhost:8080/api/FinancialSummary/current-month
```

### ❌ Erro: "Project not found"
```powershell
# Certifique-se de estar na pasta correta
cd D:\Projects\Dotnet\RaqNRollPlayground
ls taac/RaqNRollPlayground.TaaC/
```

---

## 🔄 Ciclo Completo (Do Zero)

Se estiver começando do zero:

```powershell
# 1. Iniciar containers
docker-compose up -d

# 2. Aguardar API estar pronta
Start-Sleep -Seconds 20

# 3. Compilar testes
cd taac/RaqNRollPlayground.TaaC
dotnet build

# 4. Executar testes
dotnet test

# 5. Ou usar o script
cd ../..
.\run-taac-tests.ps1 all
```

---

## 📊 Casos de Teste

Atualmente temos 6 cenários:

| # | Cenário | Endpoint | Esperado |
|---|---------|----------|----------|
| 1 | Get current month summary | `GET /api/FinancialSummary/current-month` | 200 OK |
| 2 | Get outcome summary | `GET /api/FinancialSummary/outcomes/2026-04` | 200 OK |
| 3 | Get income summary | `GET /api/FinancialSummary/incomes/2026-04` | 200 OK |
| 4 | Get financial report | `GET /api/FinancialSummary/report/2026-04` | 200 OK |
| 5 | Invalid period | `GET /api/FinancialSummary/outcomes/invalid` | 400 Error |
| 6 | API health check | `GET /` | 200/404 OK |

---

## 📈 Próximas Ações

1. ✅ Executar os testes
2. ✅ Verificar se passam
3. ⏳ Adicionar novos cenários
4. ⏳ Integrar com CI/CD
5. ⏳ Gerar relatórios

---

## 📚 Mais Informações

- [ReqNroll Docs](https://go.reqnroll.net/)
- [xUnit Docs](https://xunit.net/)
- [BDD with Gherkin](https://cucumber.io/docs/gherkin/)

---

## 🎊 Tudo Pronto!

Execute o teste agora:

```powershell
.\run-taac-tests.ps1 all
```

ou

```powershell
cd taac/RaqNRollPlayground.TaaC
dotnet test
```

**Happy Testing! 🚀**

