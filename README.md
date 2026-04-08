# RaqNRoll Playground - Controle Financeiro

## 📖 Documentação

Toda a documentação foi organizada na pasta **`docs/`**. 

### 📋 Arquivos de Documentação

| Arquivo | Descrição |
|---------|-----------|
| [`docs/README.md`](docs/README.md) | Visão geral do projeto |
| [`docs/API_ENDPOINTS.md`](docs/API_ENDPOINTS.md) | Documentação completa dos endpoints |
| [`docs/IMPLEMENTATION_SUMMARY.md`](docs/IMPLEMENTATION_SUMMARY.md) | Resumo técnico da implementação |
| [`docs/QUICK_TEST.md`](docs/QUICK_TEST.md) | Guia de teste em 2 minutos |
| [`docs/SEEDED_DATA.md`](docs/SEEDED_DATA.md) | Informações dos dados seedados |
| [`docs/DOCKER_SETUP.md`](docs/DOCKER_SETUP.md) | Setup do Docker Compose |
| [`docs/HTTP_FILES_SUMMARY.md`](docs/HTTP_FILES_SUMMARY.md) | Resumo dos arquivos .http |
| [`docs/HTTP_FILE_GUIDE.md`](docs/HTTP_FILE_GUIDE.md) | Guia de uso dos arquivos .http |
| [`docs/MIGRATIONS_RESOLUTION.md`](docs/MIGRATIONS_RESOLUTION.md) | Resolução de problemas com migrations |

---

## 🚀 Começar Rápido

### 1. Iniciar Docker
```bash
docker-compose up -d
```

### 2. Iniciar a Aplicação
```bash
dotnet run --project RaqNRollPlayground.WebApi
```

### 3. Testar Endpoints
Abra `FinancialAPI-Variables.http` no Rider/VSCode

---

## 📁 Estrutura do Projeto

```
RaqNRollPlayground/
├── docs/                          # 📖 Toda a documentação
│   ├── README.md
│   ├── API_ENDPOINTS.md
│   ├── IMPLEMENTATION_SUMMARY.md
│   ├── QUICK_TEST.md
│   ├── SEEDED_DATA.md
│   ├── DOCKER_SETUP.md
│   ├── HTTP_FILES_SUMMARY.md
│   ├── HTTP_FILE_GUIDE.md
│   └── MIGRATIONS_RESOLUTION.md
│
├── ReqNRollPlayground.Domain/     # 🎯 Camada de domínio
│   ├── Entity/
│   │   ├── Entity.cs
│   │   ├── Income.cs
│   │   ├── Outcome.cs
│   │   └── FinancialSummary.cs
│   ├── DTOs/
│   │   └── FinancialDto.cs
│   └── Services/
│       └── FinancialService.cs
│
├── RaqNRollPlayground.Infra/      # 🗄️ Camada de infraestrutura
│   ├── Context/
│   │   └── FinancialContext.cs
│   ├── Repositories/
│   │   └── FinancialRepository.cs
│   ├── Configuration/
│   │   └── InfrastructureConfiguration.cs
│   ├── Seeders/
│   │   └── DatabaseSeeder.cs
│   └── Migrations/
│       └── [EF Migrations]
│
├── RaqNRollPlayground.WebApi/     # 🌐 API REST
│   ├── Controllers/
│   │   └── FinancialSummaryController.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── FinancialAPI.http              # 🧪 Testes de API (básico)
├── FinancialAPI-Variables.http    # 🧪 Testes de API (com variáveis)
├── docker-compose.yml             # 🐳 Docker Compose (básico)
├── docker-compose.full.yml        # 🐳 Docker Compose (com pgAdmin)
├── init-db.sql                    # 🗄️ Script de inicialização
├── seed-data.sql                  # 📊 Script de dados
└── .env                           # ⚙️ Variáveis de ambiente
```

---

## 🎯 Endpoints Disponíveis

### Base URL
```
http://localhost:5000/api/financialsummary
```

### Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/outcomes/{period}` | Sumário de despesas |
| GET | `/incomes/{period}` | Sumário de receitas |
| GET | `/report/{period}` | Relatório completo |
| GET | `/current-month` | Sumário do mês atual |

**Formato do período**: `yyyy-MM` (ex: `2026-04`)

---

## 💾 Dados Disponíveis

### Receitas (Total: R$ 7.550,00)
- Salário: R$ 5.000,00
- Freelance: R$ 1.500,00
- Bônus: R$ 800,00
- Investimento: R$ 250,00

### Despesas (Total: R$ 2.694,80)
- Moradia: R$ 1.500,00
- Alimentação: R$ 535,00
- Utilitários: R$ 419,90
- Transporte: R$ 150,00
- Lazer: R$ 89,90

### Saldo: R$ 4.855,20 ✅

---

## 🏗️ Arquitetura

```
API REST (Controllers)
    ↓
Services (Business Logic)
    ↓
Repositories (Data Access)
    ↓
DbContext (Entity Framework)
    ↓
PostgreSQL Database
```

---

## 🧪 Testes

### Via Arquivo .http
1. Abra `FinancialAPI-Variables.http`
2. Clique em "Send Request" (VSCode) ou no ▶️ (Rider)
3. Veja a resposta JSON

### Via cURL
```bash
curl http://localhost:5000/api/financialsummary/current-month
```

### Via PowerShell
```powershell
Invoke-RestMethod -Uri "http://localhost:5000/api/financialsummary/current-month" | ConvertTo-Json
```

---

## 📝 Próximos Passos

1. ✅ Endpoints de sumário implementados
2. ⏭️ CRUD para Income/Outcome
3. ⏭️ Validações com FluentValidation
4. ⏭️ Paginação nos relatórios
5. ⏭️ Autenticação JWT
6. ⏭️ Cache com Redis
7. ⏭️ Swagger/OpenAPI
8. ⏭️ Testes unitários

---

## 🔧 Tecnologias

- **.NET 10** - Framework
- **PostgreSQL** - Banco de dados
- **Entity Framework Core 8** - ORM
- **Docker** - Containerização
- **Swagger/OpenAPI** - Documentação (futuro)

---

## 📖 Leitura Recomendada

Para entender melhor o projeto, leia nesta ordem:

1. **[`docs/README.md`](docs/README.md)** - Visão geral
2. **[`docs/QUICK_TEST.md`](docs/QUICK_TEST.md)** - Teste rápido
3. **[`docs/IMPLEMENTATION_SUMMARY.md`](docs/IMPLEMENTATION_SUMMARY.md)** - Arquitetura técnica
4. **[`docs/API_ENDPOINTS.md`](docs/API_ENDPOINTS.md)** - Documentação detalhada

---

## 🤝 Contribuições

Este projeto é um playground para aprender e explorar:
- Clean Architecture
- Domain-Driven Design
- Repository Pattern
- Service Pattern
- DTO Pattern
- Dependency Injection

---

## 📅 Data de Criação

2026-04-02

---

**Pronto para começar? Veja [`docs/QUICK_TEST.md`](docs/QUICK_TEST.md)!** 🚀

