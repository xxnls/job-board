using System.Net.Http.Json;
using System.Text.Json;

namespace JobBoard.Mobile.Services
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

            // If ends with "y", replace with "ies"
            if (entityTypeName.EndsWith("y"))
            {
                return $"api/{entityTypeName.Substring(0, entityTypeName.Length - 1)}ies";
            }

            // If its LocatiofForPerson, make it locations
            if (entityTypeName == "PersonCreate")
            {
                return "api/people";
            }

            if (entityTypeName == "CompanyCreate")
            {
                return "api/companies";
            }

            if (entityTypeName == "JobCreate")
            {
                return "api/jobs";
            }

            if (entityTypeName == "CategoryForJob")
            {
                return "api/categories";
            }

            if (entityTypeName == "CompanyForJob")
            {
                return "api/companies";
            }

            // If its a person, make it people
            if (entityTypeName == "Person")
            {
                return "api/people";
            }

            // If its LocatiofForPerson, make it locations
            if (entityTypeName == "LocationForPerson")
            {
                return "api/locations";
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
        public async Task<HttpResponseMessage> UpdateEntity(int id, T entity)
        {
            Console.WriteLine(GetEndpoint());
            Console.WriteLine(JsonSerializer.Serialize(entity));
            Console.WriteLine(entity);
            var response = await _http.PutAsJsonAsync($"{GetEndpoint()}/{id}", entity);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteEntity(int id)
        {
            var response = await _http.DeleteAsync($"{GetEndpoint()}/{id}");
            return response;
        }

        public async Task<List<T>> SearchEntities(string query)
        {
            var response = await _http.GetFromJsonAsync<List<T>>($"api/LocationLogic/search?query={query}");
            return response;
        }
    }
}
