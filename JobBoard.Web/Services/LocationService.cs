using System.Net.Http.Json;
using JobBoard.Web.Models;

namespace JobBoard.Web.Services
{
    public class LocationService
    {
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _http.GetFromJsonAsync<List<Location>>("api/Locations");
        }

        public async Task<Location> GetLocationById(long id)
        {
            return await _http.GetFromJsonAsync<Location>($"api/Locations/{id}");
        }
    }
}