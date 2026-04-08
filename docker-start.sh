#!/bin/bash

# Script para iniciar a aplicação com Docker Compose
# Este script simplifica o processo de inicialização

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

echo "================================================"
echo "  Financial Control API - Docker Setup"
echo "================================================"
echo ""

# Verificar se Docker está instalado
if ! command -v docker &> /dev/null; then
    echo "❌ Docker não está instalado. Por favor, instale Docker primeiro."
    exit 1
fi

echo "✅ Docker encontrado: $(docker --version)"
echo ""

# Menu de opções
echo "Escolha uma opção:"
echo "1) Iniciar containers (build + start)"
echo "2) Parar containers"
echo "3) Ver logs"
echo "4) Reconstruir imagem"
echo "5) Limpar tudo (cuidado!)"
echo "6) Verificar status"
echo ""

read -p "Digite o número da opção (1-6): " option

case $option in
    1)
        echo ""
        echo "🚀 Iniciando containers..."
        cd "$SCRIPT_DIR"
        docker-compose up -d
        echo ""
        echo "✅ Containers iniciados!"
        echo "API disponível em: http://localhost:8080"
        docker-compose ps
        ;;
    2)
        echo ""
        echo "⏹️  Parando containers..."
        cd "$SCRIPT_DIR"
        docker-compose down
        echo "✅ Containers parados!"
        ;;
    3)
        echo ""
        read -p "Ver logs de qual serviço? (postgres/api/ambos): " service
        cd "$SCRIPT_DIR"
        if [ "$service" = "postgres" ]; then
            docker-compose logs -f postgres
        elif [ "$service" = "api" ]; then
            docker-compose logs -f api
        else
            docker-compose logs -f
        fi
        ;;
    4)
        echo ""
        echo "🔨 Reconstruindo imagem..."
        cd "$SCRIPT_DIR"
        docker-compose build --no-cache
        echo "✅ Imagem reconstruída!"
        ;;
    5)
        echo ""
        echo "⚠️  AVISO: Isto vai deletar todos os containers e dados!"
        read -p "Tem certeza? (s/n): " confirm
        if [ "$confirm" = "s" ]; then
            cd "$SCRIPT_DIR"
            docker-compose down -v
            docker system prune -a -f
            echo "✅ Tudo limpado!"
        else
            echo "Operação cancelada."
        fi
        ;;
    6)
        echo ""
        echo "📊 Status dos containers:"
        cd "$SCRIPT_DIR"
        docker-compose ps
        ;;
    *)
        echo "❌ Opção inválida!"
        exit 1
        ;;
esac

