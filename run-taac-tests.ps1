#!/usr/bin/env pwsh

# Script para executar testes TaaC da API Financial

param(
    [ValidateSet('all', 'smoketest', 'api', 'clean', 'build', 'help')]
    [string]$action = 'help'
)

$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$projectPath = Join-Path $scriptPath "taac\RaqNRollPlayground.TaaC"

function Show-Banner {
    Write-Host "╔════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "║  🧪 Financial API - TaaC Smoke Tests                  ║" -ForegroundColor Cyan
    Write-Host "╚════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""
}

function Show-Menu {
    Write-Host "📋 Opções disponíveis:" -ForegroundColor Yellow
    Write-Host "  all ........... Executar todos os testes"
    Write-Host "  smoketest .... Executar apenas smoke tests"
    Write-Host "  api .......... Executar apenas testes de API"
    Write-Host "  clean ....... Limpar projeto"
    Write-Host "  build ....... Compilar projeto"
    Write-Host "  help ........ Mostrar esta mensagem"
    Write-Host ""
}

function Run-AllTests {
    Write-Host "🚀 Executando todos os testes..." -ForegroundColor Green
    Push-Location $projectPath
    dotnet test
    Pop-Location
}

function Run-SmokeTests {
    Write-Host "🚀 Executando smoke tests..." -ForegroundColor Green
    Push-Location $projectPath
    dotnet test --filter "@smoketest"
    Pop-Location
}

function Run-ApiTests {
    Write-Host "🚀 Executando testes de API..." -ForegroundColor Green
    Push-Location $projectPath
    dotnet test --filter "@api"
    Pop-Location
}

function Clean-Project {
    Write-Host "🧹 Limpando projeto..." -ForegroundColor Yellow
    Push-Location $projectPath
    dotnet clean -q
    Write-Host "✅ Projeto limpo" -ForegroundColor Green
    Pop-Location
}

function Build-Project {
    Write-Host "🔨 Compilando projeto..." -ForegroundColor Yellow
    Push-Location $projectPath
    dotnet build -q
    if ($?) {
        Write-Host "✅ Compilação bem-sucedida" -ForegroundColor Green
    }
    else {
        Write-Host "❌ Falha na compilação" -ForegroundColor Red
    }
    Pop-Location
}

function Show-Help {
    Show-Menu
    Write-Host "Exemplos:" -ForegroundColor Cyan
    Write-Host "  .\run-taac-tests.ps1 all"
    Write-Host "  .\run-taac-tests.ps1 smoketest"
    Write-Host "  .\run-taac-tests.ps1 api"
    Write-Host "  .\run-taac-tests.ps1 build"
    Write-Host ""
}

# Verificar se o projeto existe
if (-not (Test-Path $projectPath)) {
    Write-Host "❌ Projeto não encontrado em: $projectPath" -ForegroundColor Red
    exit 1
}

Show-Banner

switch ($action) {
    'all' { Run-AllTests }
    'smoketest' { Run-SmokeTests }
    'api' { Run-ApiTests }
    'clean' { Clean-Project }
    'build' { Build-Project }
    'help' { Show-Help }
    default {
        Write-Host "Menu interativo:" -ForegroundColor Yellow
        Show-Menu
        $choice = Read-Host "Escolha uma opção (all/smoketest/api/clean/build/help)"
        & $MyInvocation.MyCommand.Path -action $choice
    }
}

