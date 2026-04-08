using System;
using System.Threading.Tasks;
using Reqnroll;
using RaqNRollPlayground.TaaC.HttpClients;
using Xunit;

namespace RaqNRollPlayground.TaaC.StepDefinitions;

[Binding]
public sealed class FinancialApiStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private FinancialSummaryApiClient? _financialSummaryApiClient;
    private ApiResponse? _lastResponse;
    private string? _baseUrl;
    private string? _currentPeriod;

    public FinancialApiStepDefinitions(ScenarioContext scenarioContext, FinancialSummaryApiClient financialSummaryApiClient)
    {
        _scenarioContext = scenarioContext;
        _financialSummaryApiClient = financialSummaryApiClient;
    }

    [Given("the API is running at {string}")]
    public void GivenTheApiIsRunningAt(string baseUrl)
    {
        _baseUrl = baseUrl;
        _financialSummaryApiClient.SetBaseUrl(baseUrl);
        
        _scenarioContext["ApiClient"] = _financialSummaryApiClient;
        _scenarioContext["BaseUrl"] = baseUrl;
    }

    [Given("the current period is {string}")]
    public void GivenTheCurrentPeriodIs(string period)
    {
        _currentPeriod = period;
        _scenarioContext["CurrentPeriod"] = period;
    }

    [When("I call the endpoint {string}")]
    public async Task WhenICallTheEndpoint(string endpoint)
    {
        var apiClient = _scenarioContext.Get<FinancialSummaryApiClient>("ApiClient");
        
        // Substituir variáveis no endpoint
        endpoint = endpoint.Replace("[period]", _currentPeriod ?? "2026-04");
        
        // Extrair método HTTP e caminho
        var parts = endpoint.Split(' ');
        var method = parts[0];
        var path = parts[1];

        _lastResponse = method switch
        {
            "GET" => await apiClient.GetAsync(path),
            "POST" => await apiClient.PostAsync(path, new StringContent("{}", System.Text.Encoding.UTF8, "application/json")),
            _ => throw new NotImplementedException($"Método HTTP {method} não implementado")
        };

        _scenarioContext["LastResponse"] = _lastResponse;
    }

    [When("I make a GET request to the root endpoint")]
    public async Task WhenIMakeAGetRequestToTheRootEndpoint()
    {
        var apiClient = _scenarioContext.Get<FinancialSummaryApiClient>("ApiClient");
        _lastResponse = await apiClient.GetAsync("/");
        _scenarioContext["LastResponse"] = _lastResponse;
    }

    [Then("the response status should be {int}")]
    public void ThenTheResponseStatusShouldBe(int expectedStatus)
    {
        var response = _scenarioContext.Get<ApiResponse>("LastResponse");
        Assert.Equal(expectedStatus, response.StatusCode);
    }

    [Then("the response status should be {int} or {int}")]
    public void ThenTheResponseStatusShouldBeOr(int status1, int status2)
    {
        var response = _scenarioContext.Get<ApiResponse>("LastResponse");
        Assert.True(
            response.StatusCode == status1 || response.StatusCode == status2,
            $"Status esperado {status1} ou {status2}, mas recebeu {response.StatusCode}"
        );
    }

    [Then("the response should contain a valid JSON")]
    public void ThenTheResponseShouldContainAValidJson()
    {
        var response = _scenarioContext.Get<ApiResponse>("LastResponse");
        Assert.NotNull(response.Content);
        Assert.True(response.IsValidJson(), $"Resposta não é um JSON válido: {response.Content}");
    }

    [Then("the response should contain error message")]
    public void ThenTheResponseShouldContainErrorMessage()
    {
        var response = _scenarioContext.Get<ApiResponse>("LastResponse");
        Assert.NotNull(response.Content);
        Assert.True(
            response.Content.Contains("erro", StringComparison.OrdinalIgnoreCase) ||
            response.Content.Contains("error", StringComparison.OrdinalIgnoreCase) ||
            response.Content.Contains("message", StringComparison.OrdinalIgnoreCase),
            $"Resposta não contém mensagem de erro: {response.Content}"
        );
    }

    [Then("the API should be responsive")]
    public void ThenTheApiShouldBeResponsive()
    {
        var response = _scenarioContext.Get<ApiResponse>("LastResponse");
        Assert.NotNull(response);
        Assert.NotEqual(0, response.StatusCode);
    }
}

