# 📄 Arquivos .http para Teste de API

## 🎉 O que foi criado

### 2 Arquivos .http

#### 1️⃣ `FinancialAPI.http` (Básico)
- ✅ 4 endpoints principais
- ✅ Testes com diferentes períodos
- ✅ Testes de validação/erro
- ✅ Exemplos com variáveis (comentado)
- 📍 Ideal para começar

#### 2️⃣ `FinancialAPI-Variables.http` (Avançado)
- ✅ Variáveis pré-configuradas
- ✅ Testes de performance
- ✅ Múltiplos períodos
- ✅ Instruções de uso integradas
- 📍 Ideal para testes recorrentes

---

## 🚀 Uso Rápido

### No JetBrains Rider

1. **Abrir o arquivo**
   - Clique em `FinancialAPI.http`

2. **Executar requisição**
   - Clique no ícone ▶️ verde
   - Ou tecle `Ctrl+Alt+E`

3. **Ver resposta**
   - Painel à direita mostra JSON
   - Status code no topo

### No Visual Studio Code

1. **Instalar extensão**
   ```
   Extensions → REST Client → Instalar
   ```

2. **Abrir o arquivo**
   - Clique em `FinancialAPI.http`

3. **Executar requisição**
   - Clique em "Send Request"
   - Ou tecle `Ctrl+Alt+E`

4. **Ver resposta**
   - Aba "REST Client" mostra resultado

---

## 📋 Conteúdo do FinancialAPI.http

### Seção 1: Endpoints Principais (4)
```http
GET /api/financialsummary/outcomes/2026-04        # Despesas
GET /api/financialsummary/incomes/2026-04         # Receitas
GET /api/financialsummary/report/2026-04          # Relatório
GET /api/financialsummary/current-month           # Mês Atual
```

### Seção 2: Testes Adicionais (2)
```http
GET /api/financialsummary/outcomes/2026-03        # Período diferente
GET /api/financialsummary/incomes/2026-05         # Período futuro
```

### Seção 3: Testes de Erro (2)
```http
GET /api/financialsummary/outcomes/invalid        # Período inválido
GET /api/financialsummary/outcomes/04-2026        # Formato errado
```

### Seção 4: Exemplos com Variáveis (Comentado)
```http
@baseUrl = http://localhost:5000
@period = 2026-04

GET {{baseUrl}}/api/financialsummary/{{period}}
```

---

## 📋 Conteúdo do FinancialAPI-Variables.http

### Variáveis Pré-Configuradas
```http
@baseUrl = http://localhost:5000
@contentType = application/json
@period = 2026-04
@periodPrev = 2026-03
@periodNext = 2026-05
```

### Endpoints Principais (4)
Todos usando as variáveis

### Testes com Múltiplos Períodos (4)
- Período anterior
- Próximo período
- Períodos específicos

### Testes de Validação (3)
- Período inválido
- Formato errado
- Período vazio

### Testes de Períodos Específicos (3)
- Janeiro, Fevereiro, Dezembro

### Testes de Performance (4)
Múltiplas requisições em sequência

---

## ✨ Recursos Principais

### ✅ Separador de Requisições
```http
###
```
Cada `###` separa uma requisição da próxima

### ✅ Comentários
```http
### Este é um comentário
# Outro comentário
```

### ✅ Variáveis
```http
@baseUrl = http://localhost:5000
GET {{baseUrl}}/api/endpoint
```

### ✅ Headers
```http
GET http://localhost:5000/api/endpoint
Accept: application/json
Authorization: Bearer token
```

---

## 🎯 Exemplos Práticos

### Teste 1: Ver Despesas do Mês
1. Abra `FinancialAPI.http`
2. Clique no ▶️ da primeira requisição
3. Veja o JSON com as despesas

### Teste 2: Mudar Período
1. Abra `FinancialAPI-Variables.http`
2. Mude `@period = 2026-05`
3. Execute qualquer requisição
4. Todas usarão maio automaticamente

### Teste 3: Testar Erros
1. Execute a requisição com "invalid"
2. Veja o erro 400
3. Confirma validação está funcionando

---

## 📊 Saída Esperada

### Requisição: current-month
**Status**: 200 OK
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

## 🔧 Editar os Arquivos

### Adicionar Nova Requisição
```http
###

### Nome da Nova Requisição
GET http://localhost:5000/api/novo-endpoint
Accept: application/json
```

### Adicionar Header
```http
GET http://localhost:5000/api/financialsummary/current-month
Accept: application/json
Authorization: Bearer seu-token
```

### Usar Variáveis
```http
@novaUrl = http://novo-servidor
GET {{novaUrl}}/api/financialsummary/current-month
```

---

## 📁 Estrutura de Arquivos

```
RaqNRollPlayground/
├── FinancialAPI.http              ⭐ Básico - Comece por aqui
├── FinancialAPI-Variables.http    ⭐ Avançado - Com variáveis
├── HTTP_FILE_GUIDE.md             📖 Guia completo
├── API_ENDPOINTS.md               📖 Documentação de endpoints
└── ... (outros arquivos)
```

---

## 💡 Dicas

✅ **Use `###` para separar requisições**
- Facilita a leitura
- Permite executar uma por vez

✅ **Use variáveis para reutilizar valores**
- Mude em um lugar
- Aplica em todas as requisições

✅ **Comente suas requisições**
- Indique o que cada uma faz
- Facilita para outros usarem

✅ **Organize por seções**
- Endpoints principais
- Testes
- Validações

✅ **Teste antes de usar em produção**
- Sempre teste localmente primeiro
- Verifique os dados

---

## 🐛 Troubleshooting

| Problema | Solução |
|----------|---------|
| "Connection refused" | Inicie a API com `dotnet run` |
| "404 Not Found" | Verifique a URL e o período |
| "Bad Request" | Use formato `2026-04` (não `04-2026`) |
| VSCode: Sem "Send Request" | Instale extensão REST Client |
| Variáveis não funcionam | Use `{{nomedavariavel}}` |

---

## 📚 Próximos Passos

1. ✅ Abra um dos arquivos .http
2. ✅ Execute uma requisição
3. ✅ Veja a resposta JSON
4. ✅ Teste os 4 endpoints
5. ✅ Teste com diferentes períodos
6. ✅ Teste as validações

---

## 📞 Documentação Relacionada

- 📖 `HTTP_FILE_GUIDE.md` - Guia detalhado
- 📖 `API_ENDPOINTS.md` - Documentação de endpoints
- 📖 `QUICK_TEST.md` - Teste em 2 minutos
- 📖 `IMPLEMENTATION_SUMMARY.md` - Arquitetura técnica

---

## ✅ Status

| Item | Status |
|------|--------|
| FinancialAPI.http | ✅ Criado |
| FinancialAPI-Variables.http | ✅ Criado |
| Documentação | ✅ Completa |
| Exemplos | ✅ Inclusos |
| Testes | ✅ Prontos |

---

**Pronto para testar! Abra o arquivo no Rider/VSCode e comece! 🚀**

