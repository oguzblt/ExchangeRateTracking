using ExchangeRateTracking.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace ExchangeRateTracking.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CurrencyService> _logger;

        public CurrencyService(HttpClient httpClient, IConfiguration configuration, ILogger<CurrencyService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<CurrencyResponse?> GetRatesAsync(string baseCurrency)
        {
            var apiKey = _configuration["ExchangeRateApiKey"];
            var url = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/{baseCurrency}";

            try
            {
                _logger.LogInformation($"Fetching rates for {baseCurrency} from: {url}");
                var response = await _httpClient.GetFromJsonAsync<CurrencyResponse>(url);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch currency rates for {baseCurrency}");
                return null;
            }
        }
    }
}
