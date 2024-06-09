using System.Net.Http.Json;
using JobBoard.Web.Dtos;

namespace JobBoard.Web.Services
{
    public class JobService
    {
        private readonly HttpClient _http;

        public JobService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<JobDto>> GetJobs()
        {
            return await _http.GetFromJsonAsync<List<JobDto>>("api/Jobs");
        }

        public async Task<JobDto> GetJobById(long id)
        {
            return await _http.GetFromJsonAsync<JobDto>($"api/Jobs/{id}");
        }
    }
}