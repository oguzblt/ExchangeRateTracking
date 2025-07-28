using System.Text.Json.Serialization;

namespace ExchangeRateTracking.Models
{
    public class CurrencyResponse
    {
        [JsonPropertyName("base_code")]
        public string Base { get; set; }

        [JsonPropertyName("conversion_rates")]
        public Dictionary<string, decimal> Rates { get; set; }

        [JsonPropertyName("time_last_update_utc")]
        public string Date { get; set; }
    }
}
