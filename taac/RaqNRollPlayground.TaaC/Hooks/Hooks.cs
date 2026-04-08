using System;
using System.Threading.Tasks;
using Reqnroll;

namespace RaqNRollPlayground.TaaC.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario(Order = 1)]
    public async Task BeforeScenario()
    {
        Console.WriteLine($"🧪 Iniciando cenário: {_scenarioContext.ScenarioInfo.Title}");
        Console.WriteLine($"   Tags: {string.Join(", ", _scenarioContext.ScenarioInfo.Tags)}");
        
        // Aguardar um pouco para a API estar pronta
        await Task.Delay(500);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        var result = _scenarioContext.TestError == null ? "✅ PASSOU" : "❌ FALHOU";
        Console.WriteLine($"   Resultado: {result}");
        
        if (_scenarioContext.TestError != null)
        {
            Console.WriteLine($"   Erro: {_scenarioContext.TestError.Message}");
        }
    }

    [BeforeScenario("@smoketest")]
    public void BeforeSmokeTest()
    {
        Console.WriteLine("   📊 Executando Smoke Test");
    }

    [AfterScenario("@api")]
    public void AfterApiScenario()
    {
        // Limpeza específica para testes de API
        if (_scenarioContext.TryGetValue("LastResponse", out var response))
        {
            Console.WriteLine("   📨 Resposta da API foi registrada");
        }
    }
}

