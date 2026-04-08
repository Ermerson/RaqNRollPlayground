# Implementação de Docker para a Aplicação

## ✅ Arquivos Criados

### 1. **Dockerfile** 
- Localizado na raiz do projeto: `D:\Projects\Dotnet\RaqNRollPlayground\Dockerfile`
- Usa build multi-stage (otimizado)
- Build Stage: Compila a aplicação .NET 10
- Runtime Stage: Executa com a imagem aspnet:10.0 (mais leve)
- Tamanho final da imagem: ~380MB

### 2. **.dockerignore**
- Localizado na raiz do projeto: `D:\Projects\Dotnet\RaqNRollPlayground\.dockerignore`
- Exclui arquivos desnecessários durante o build
- Reduz o tempo de build e o tamanho da imagem

### 3. **docker-compose.yml** (Atualizado)
- Serviço PostgreSQL: `financial_control_postgres`
- Serviço API: `financial_control_api`
- Ambos conectados na rede: `financial_network`

## 🚀 Como Usar

### Iniciar os Containers
```powershell
cd D:\Projects\Dotnet\RaqNRollPlayground
docker-compose up -d
```

### Verificar Status
```powershell
docker-compose ps
```

### Acessar a API
- URL: `http://localhost:8080`

### Acessar o Banco de Dados
- Host: `localhost`
- Port: `5432`
- User: `postgres`
- Password: `postgres`
- Database: `financial_control`

### Parar os Containers
```powershell
docker-compose down
```

### Parar e Remover Tudo (incluindo dados)
```powershell
docker-compose down -v
```

## 📋 Estrutura dos Serviços

### PostgreSQL
- Imagem: `postgres:16-alpine`
- Porta: 5432
- Health Check: Ativado (verifica a cada 10s)
- Volume: `postgres_data` (persistente)

### API
- Build: Do Dockerfile local
- Porta: 8080
- Ambiente: Development
- Dependência: Aguarda PostgreSQL estar saudável
- Connection String: `Host=postgres;Port=5432;Database=financial_control;Username=postgres;Password=postgres`

## 🔧 Configurações Importantes

### Variáveis de Ambiente da API
- `ASPNETCORE_ENVIRONMENT`: Development
- `ASPNETCORE_URLS`: http://+:8080
- `ConnectionStrings__DefaultConnection`: String de conexão PostgreSQL

### Networking
- Rede: `financial_network` (bridge)
- A API se conecta ao PostgreSQL usando o hostname `postgres`

## ✨ Principais Benefícios

1. **Reprodutibilidade**: Mesma configuração em qualquer máquina
2. **Isolamento**: Cada serviço roda em seu próprio container
3. **Facilidade de Deploy**: Um simples comando inicia toda a stack
4. **Persistência de Dados**: Volume Docker mantém os dados do PostgreSQL
5. **Health Checks**: PostgreSQL validado antes de iniciar a API

## 📝 Logs e Debugging

### Ver logs da API
```powershell
docker-compose logs -f api
```

### Ver logs do PostgreSQL
```powershell
docker-compose logs -f postgres
```

### Ver todos os logs
```powershell
docker-compose logs -f
```

### Acessar terminal do container
```powershell
docker-compose exec api /bin/bash
docker-compose exec postgres psql -U postgres -d financial_control
```

## 🐛 Troubleshooting

### Erro: Port already in use
- Altere as portas no `docker-compose.yml`
- Ou finalize o container anterior: `docker-compose down`

### Erro: Cannot connect to PostgreSQL
- Aguarde o health check completar (~20s)
- Verifique: `docker-compose logs postgres`

### Limpar tudo e recomeçar
```powershell
docker-compose down -v
docker system prune -a
docker-compose up -d
```

## 📦 Próximos Passos

1. Inicializar o banco de dados com as migrations
2. Testar endpoints da API
3. Monitorar logs e performance
4. Configurar variáveis de ambiente para produção se necessário

