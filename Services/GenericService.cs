using BlazorFutbol.Class;
using BlazorFutbol.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly HttpClient client;
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };
    private readonly string _endpoint;

    public GenericService(HttpClient client)
    {
        this.client = client;
        this._endpoint = ApiEndPoints.GetEndpoint(typeof(T).Name);
    }

    public async Task<List<T>?> GetAllAsync()
    {
        var response = await client.GetAsync(_endpoint);
        response.EnsureSuccessStatusCode(); // Lanza una excepción si el código no es 200
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<T>>(content, options);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var fullEndpoint = $"{_endpoint}/{id}";
        var response = await client.GetAsync(fullEndpoint);
        response.EnsureSuccessStatusCode(); // Lanza una excepción si el código no es 200
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content, options);
    }

    public async Task<T?> AddAsync(T? entity)
    {
        var response = await client.PostAsJsonAsync(_endpoint, entity);
        response.EnsureSuccessStatusCode(); // Lanza una excepción si el código no es 200
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content, options);
    }

    public async Task UpdateAsync(T? entity)
    {
        var idValue = entity?.GetType().GetProperty("Id")?.GetValue(entity);

        if (idValue == null)
        {
            throw new ApplicationException("No se pudo encontrar la propiedad 'Id' en la entidad.");
        }

        var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
        response.EnsureSuccessStatusCode(); // Lanza una excepción si el código no es 200
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"{_endpoint}/{id}");
        response.EnsureSuccessStatusCode(); // Lanza una excepción si el código no es 200
    }
}