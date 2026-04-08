#!/bin/bash
# Script para executar testes TaaC da API Financial

# Cores
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${BLUE}╔════════════════════════════════════════════════════════╗${NC}"
echo -e "${BLUE}║  🧪 Financial API - TaaC Smoke Tests                  ║${NC}"
echo -e "${BLUE}╚════════════════════════════════════════════════════════╝${NC}"
echo ""

# Navegar para a pasta do projeto
cd "$(dirname "$0")/taac/RaqNRollPlayground.TaaC"

echo -e "${YELLOW}📋 Opções de teste:${NC}"
echo "1. Executar todos os testes"
echo "2. Executar apenas smoke tests"
echo "3. Executar apenas testes de API"
echo "4. Executar com filtro personalizado"
echo "5. Limpar e reconstruir"
echo "6. Ver relatório HTML"
echo ""

read -p "Escolha uma opção (1-6): " option

case $option in
    1)
        echo -e "${GREEN}🚀 Executando todos os testes...${NC}"
        dotnet test
        ;;
    2)
        echo -e "${GREEN}🚀 Executando smoke tests...${NC}"
        dotnet test --filter "@smoketest"
        ;;
    3)
        echo -e "${GREEN}🚀 Executando testes de API...${NC}"
        dotnet test --filter "@api"
        ;;
    4)
        read -p "Digite o filtro (ex: @smoketest @api): " filter
        echo -e "${GREEN}🚀 Executando testes com filtro: $filter${NC}"
        dotnet test --filter "$filter"
        ;;
    5)
        echo -e "${YELLOW}🧹 Limpando projeto...${NC}"
        dotnet clean
        echo -e "${GREEN}✅ Projeto limpo${NC}"
        echo -e "${YELLOW}🔨 Reconstruindo...${NC}"
        dotnet build
        ;;
    6)
        echo -e "${GREEN}📊 Abrindo relatório HTML...${NC}"
        if [ -f "bin/Debug/net10.0/Reports/LivingDoc.html" ]; then
            open "bin/Debug/net10.0/Reports/LivingDoc.html" 2>/dev/null || xdg-open "bin/Debug/net10.0/Reports/LivingDoc.html" 2>/dev/null || echo "Relatório em: bin/Debug/net10.0/Reports/LivingDoc.html"
        else
            echo "❌ Relatório não encontrado. Execute os testes primeiro."
        fi
        ;;
    *)
        echo "❌ Opção inválida"
        exit 1
        ;;
esac

