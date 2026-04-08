# 🐳 Docker Compose Setup

## 📋 Arquivos Criados

- **docker-compose.yml**: Configuração básica com PostgreSQL
- **docker-compose.full.yml**: Configuração completa com PostgreSQL + pgAdmin
- **init-db.sql**: Script de inicialização do banco de dados
- **.env**: Variáveis de ambiente

## 🚀 Como Usar

### 1. Iniciar os containers (Básico)

```bash
docker-compose up -d
```

### 2. Iniciar os containers (Com pgAdmin)

```bash
docker-compose -f docker-compose.full.yml up -d
```

### 3. Parar os containers

```bash
docker-compose down
```

### 4. Visualizar os logs

```bash
docker-compose logs -f postgres
```

## 📊 Acessar o Banco de Dados

### Via Command Line

```bash
docker exec -it financial_control_postgres psql -U postgres -d financial_control
```

### Via pgAdmin (se estiver usando docker-compose.full.yml)

- URL: http://localhost:5050
- Email: admin@example.com
- Password: admin

**Adicionar servidor:**
1. Clique em "Servers" → "Register" → "Server"
2. Name: financial_control
3. Host: postgres
4. Username: postgres
5. Password: postgres

## 🔧 Comandos Úteis

### Limpar todos os dados e reconstruir

```bash
docker-compose down -v
docker-compose up -d
```

### Verificar status dos containers

```bash
docker-compose ps
```

### Inspecionar configurações

```bash
docker-compose config
```

### Executar migrations do EF

```bash
dotnet ef database update --project RaqNRollPlayground.Infra --startup-project RaqNRollPlayground.WebApi
```

## 🔌 Connection String

Se estiver rodando a aplicação .NET fora do Docker:

```
Host=localhost;Port=5432;Database=financial_control;Username=postgres;Password=postgres
```

Se estiver rodando dentro do Docker (mesmo network):

```
Host=postgres;Port=5432;Database=financial_control;Username=postgres;Password=postgres
```

## 📝 Variáveis de Ambiente

As variáveis estão definidas no arquivo `.env`:

```env
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres
POSTGRES_DB=financial_control
DB_PORT=5432
```

Você pode modificá-las conforme necessário.

## ⚠️ Notas Importantes

1. **Volume de Dados**: Os dados persistem em um volume Docker chamado `postgres_data`
2. **Health Check**: O PostgreSQL passa pelo health check antes de estar pronto
3. **Network**: Um network `financial_network` é criado para comunicação entre containers
4. **Restart Policy**: O PostgreSQL reinicia automaticamente se o container cair

## 🛠️ Solução de Problemas

### Porta 5432 já está em uso

```bash
# Mude a porta no docker-compose.yml:
ports:
  - "5433:5432"  # Use 5433 ao invés de 5432
```

### Erro de conexão

```bash
# Verifique se o container está rodando
docker-compose ps

# Verifique os logs
docker-compose logs postgres

# Reinicie os containers
docker-compose restart
```

### Resetar banco de dados

```bash
# Remove tudo
docker-compose down -v

# Reinicia
docker-compose up -d
```

