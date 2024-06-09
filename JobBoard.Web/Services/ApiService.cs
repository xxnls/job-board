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

            //entityTypeName = entityTypeName.ToLower();

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
        public async Task CreateEntity(T entity)
        {
            var response = await _http.PostAsJsonAsync(GetEndpoint(), entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
