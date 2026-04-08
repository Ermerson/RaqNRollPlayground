using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaqNRollPlayground.TaaC.HttpClients;

/// <summary>
/// Helper para fazer requisições HTTP aos endpoints da API
/// </summary>
public class FinancialSummaryApiClient
{
    private readonly HttpClient _httpClient;
    private string? _baseUrl;

    public FinancialSummaryApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("FinancialAPI");
    }

    /// <summary>
    /// Define a URL base da API
    /// </summary>
    public void SetBaseUrl(string baseUrl)
    {
        _baseUrl = baseUrl;
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    /// <summary>
    /// Faz uma requisição GET
    /// </summary>
    public async Task<ApiResponse> GetAsync(string endpoint)
    {
        if (string.IsNullOrEmpty(_baseUrl))
            throw new InvalidOperationException("Base URL não foi configurada. Use SetBaseUrl() primeiro.");

        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            return new ApiResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = content,
                IsSuccess = response.IsSuccessStatusCode
            };
        }
        catch (HttpRequestException ex)
        {
            return new ApiResponse
            {
                StatusCode = 0,
                Content = ex.Message,
                IsSuccess = false,
                Error = ex
            };
        }
    }

    /// <summary>
    /// Faz uma requisição POST
    /// </summary>
    public async Task<ApiResponse> PostAsync(string endpoint, StringContent content)
    {
        if (string.IsNullOrEmpty(_baseUrl))
            throw new InvalidOperationException("Base URL não foi configurada. Use SetBaseUrl() primeiro.");

        try
        {
            var response = await _httpClient.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            return new ApiResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = responseContent,
                IsSuccess = response.IsSuccessStatusCode
            };
        }
        catch (HttpRequestException ex)
        {
            return new ApiResponse
            {
                StatusCode = 0,
                Content = ex.Message,
                IsSuccess = false,
                Error = ex
            };
        }
    }

    /// <summary>
    /// Testa a conectividade com a API
    /// </summary>
    public async Task<bool> IsApiAccessibleAsync()
    {
        if (string.IsNullOrEmpty(_baseUrl))
            return false;

        try
        {
            using (var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                var response = await _httpClient.GetAsync("/", cts.Token);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}

/// <summary>
/// Resposta da API
/// </summary>
public class ApiResponse
{
    public int StatusCode { get; set; }
    public string? Content { get; set; }
    public bool IsSuccess { get; set; }
    public Exception? Error { get; set; }

    public bool IsValidJson()
    {
        if (string.IsNullOrEmpty(Content))
            return false;

        try
        {
            Newtonsoft.Json.Linq.JObject.Parse(Content);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

