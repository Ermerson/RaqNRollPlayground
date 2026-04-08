# Script para iniciar a aplicação com Docker Compose no Windows
# Este script simplifica o processo de inicialização

param(
    [ValidateSet('start', 'stop', 'logs', 'rebuild', 'clean', 'status')]
    [string]$action = 'menu'
)

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

function Show-Menu {
    Clear-Host
    Write-Host "================================================" -ForegroundColor Cyan
    Write-Host "  Financial Control API - Docker Setup" -ForegroundColor Cyan
    Write-Host "================================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Escolha uma opção:" -ForegroundColor Yellow
    Write-Host "1) Iniciar containers (build + start)" -ForegroundColor White
    Write-Host "2) Parar containers" -ForegroundColor White
    Write-Host "3) Ver logs" -ForegroundColor White
    Write-Host "4) Reconstruir imagem" -ForegroundColor White
    Write-Host "5) Limpar tudo (cuidado!)" -ForegroundColor White
    Write-Host "6) Verificar status" -ForegroundColor White
    Write-Host "0) Sair" -ForegroundColor White
    Write-Host ""
}

function Test-Docker {
    try {
        $version = docker --version
        Write-Host "✅ Docker encontrado: $version" -ForegroundColor Green
        return $true
    }
    catch {
        Write-Host "❌ Docker não está instalado. Por favor, instale Docker primeiro." -ForegroundColor Red
        return $false
    }
}

function Start-Containers {
    Write-Host ""
    Write-Host "🚀 Iniciando containers..." -ForegroundColor Cyan
    Push-Location $scriptDir
    docker-compose up -d
    Write-Host ""
    Write-Host "✅ Containers iniciados!" -ForegroundColor Green
    Write-Host "API disponível em: http://localhost:8080" -ForegroundColor Green
    docker-compose ps
    Pop-Location
}

function Stop-Containers {
    Write-Host ""
    Write-Host "⏹️  Parando containers..." -ForegroundColor Yellow
    Push-Location $scriptDir
    docker-compose down
    Write-Host "✅ Containers parados!" -ForegroundColor Green
    Pop-Location
}

function Show-Logs {
    Write-Host ""
    Write-Host "Qual serviço deseja ver os logs?" -ForegroundColor Yellow
    Write-Host "1) PostgreSQL"
    Write-Host "2) API"
    Write-Host "3) Todos"
    $choice = Read-Host "Digite sua escolha (1-3)"
    
    Push-Location $scriptDir
    switch ($choice) {
        '1' { docker-compose logs -f postgres }
        '2' { docker-compose logs -f api }
        default { docker-compose logs -f }
    }
    Pop-Location
}

function Rebuild-Image {
    Write-Host ""
    Write-Host "🔨 Reconstruindo imagem..." -ForegroundColor Cyan
    Push-Location $scriptDir
    docker-compose build --no-cache
    Write-Host "✅ Imagem reconstruída!" -ForegroundColor Green
    Pop-Location
}

function Clean-All {
    Write-Host ""
    Write-Host "⚠️  AVISO: Isto vai deletar todos os containers e dados!" -ForegroundColor Red
    $confirm = Read-Host "Tem certeza? (s/n)"
    
    if ($confirm -eq 's') {
        Push-Location $scriptDir
        docker-compose down -v
        docker system prune -a -f
        Write-Host "✅ Tudo limpado!" -ForegroundColor Green
        Pop-Location
    }
    else {
        Write-Host "Operação cancelada." -ForegroundColor Yellow
    }
}

function Show-Status {
    Write-Host ""
    Write-Host "📊 Status dos containers:" -ForegroundColor Cyan
    Push-Location $scriptDir
    docker-compose ps
    Pop-Location
}

# Main execution
if (-not (Test-Docker)) {
    exit 1
}

if ($action -eq 'menu') {
    do {
        Show-Menu
        $option = Read-Host "Digite o número da opção (0-6)"
        
        switch ($option) {
            '1' { Start-Containers }
            '2' { Stop-Containers }
            '3' { Show-Logs }
            '4' { Rebuild-Image }
            '5' { Clean-All }
            '6' { Show-Status }
            '0' { exit 0 }
            default { Write-Host "❌ Opção inválida!" -ForegroundColor Red }
        }
        
        if ($option -ne '0') {
            Read-Host "Pressione Enter para continuar"
        }
    } while ($option -ne '0')
}
else {
    switch ($action) {
        'start' { Start-Containers }
        'stop' { Stop-Containers }
        'logs' { Show-Logs }
        'rebuild' { Rebuild-Image }
        'clean' { Clean-All }
        'status' { Show-Status }
    }
}

