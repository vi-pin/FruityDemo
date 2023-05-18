using FruityDemo.Models;
using Microsoft.Extensions.Options;

namespace FruityDemo.Services
{
    public class FruitService : IFruitService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _configuration;

        public FruitService(IHttpClientFactory httpClientFactory, IOptions<AppSettings> configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<Fruit>> GetAllFruits()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiUrl = _configuration.Value.FruityViceApiUrl;
            var response = await httpClient.GetAsync(apiUrl + "all");
            var fruits = await response.Content.ReadFromJsonAsync<List<Fruit>>();
            return fruits;
        }

        public async Task<List<Fruit>> GetFruitsByFamily(string fruitFamily)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiUrl = _configuration.Value.FruityViceApiUrl;
            var response = await httpClient.GetAsync(apiUrl + "family/" + fruitFamily);
            var fruits = await response.Content.ReadFromJsonAsync<List<Fruit>>();
            return fruits;
        }
    }
}
