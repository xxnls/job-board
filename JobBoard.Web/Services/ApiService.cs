using System.Text.Json;

namespace JobBoard.Web.Services
{
    public class ApiService<T> where T : class
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        private string GetEndpoint()
        {
            string entityTypeName = typeof(T).Name;

            // Remove the "Dto" suffix
            if (entityTypeName.EndsWith("Dto"))
            {
                entityTypeName = entityTypeName.Substring(0, entityTypeName.Length - 3);
            }

            return $"api/{entityTypeName}s"; // Make plural
        }

        public async Task<List<T>> GetEntities()
        {
            return await _http.GetFromJsonAsync<List<T>>(GetEndpoint());
        }

        public async Task<T> GetEntityById(long id)
        {
            return await _http.GetFromJsonAsync<T>($"{GetEndpoint()}/{id}");
        }
        public async Task<HttpResponseMessage> CreateEntity(T entity)
        {
            Console.WriteLine(GetEndpoint());
            Console.WriteLine(JsonSerializer.Serialize(entity));
            Console.WriteLine(entity);
            var response = await _http.PostAsJsonAsync(GetEndpoint(), entity);
            return response;
        }
    }
}
