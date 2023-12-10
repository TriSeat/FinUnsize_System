using FinUnsize.Helpers;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace FinUnsize.Response;

public class ApiResponse
{
    private readonly HttpClient _httpCliente;
    private readonly ICookieManager _cookieManager;
    private readonly NavigationManager _navigation;

    public ApiResponse(HttpClient httpClient, ICookieManager cookieManager, NavigationManager navigation)
    {
        _httpCliente = httpClient;
        _cookieManager = cookieManager;
        _navigation = navigation;
    }

    public async Task<string> Login(string endpoint, string login, string password)
    {
        var credentials = new { login = login, password = password};
        var content = Serialize(credentials);
        var response = await _httpCliente.PostAsync(endpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            await SaveToken(token);
            return "200";
        }
        return "erro";
    }

    public async Task<Credentials> Credentials()
    {

        var response = await _httpCliente.GetAsync("user/credentials");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Credentials>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        return null;
    }

    public async Task AuthorizationHeader()
    {
        string token = await _cookieManager.GetValue();

        if (string.IsNullOrEmpty(token))
        {
            _navigation.NavigateTo("/user/login");
        }

        _httpCliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private async Task SaveToken(string token)
    {
        await _cookieManager.SetValue(token, 3);
    }

    public StringContent Serialize(object payload) 
    {
        return new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
    }
}