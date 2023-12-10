using Newtonsoft.Json;

namespace FinUnsize.Response;

public class ApiService
{

    private readonly HttpClient _httpClient;


    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<T>> Get<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
        }

        return null;
    }

    public async Task<T> GetUnique<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }

    public async Task<T> Post<T>(string endpoint, object data)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(endpoint, data);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }

    public async Task<T> Put<T>(string endpoint, object data)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync(endpoint, data);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }
}
