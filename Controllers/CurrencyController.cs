using ExchangeRateTracking.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateTracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        private readonly List<string> _favoriteCurrencies = new() { "TRY", "EUR", "GBP", "USD" };

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates([FromQuery] string baseCurrency = "USD")
        {
            if (string.IsNullOrWhiteSpace(baseCurrency) || baseCurrency.Length != 3)
            {
                return BadRequest("Geçerli bir 3 harfli para birimi giriniz. Örnek: USD, TRY");
            }

            var result = await _currencyService.GetRatesAsync(baseCurrency.ToUpper());

            if (result == null || result.Rates == null)
            {
                return StatusCode(502, "Kur bilgileri alınamadı. Lütfen daha sonra tekrar deneyin.");
            }

            var filteredRates = result.Rates
                .Where(rate => _favoriteCurrencies.Contains(rate.Key))
                .ToDictionary(rate => rate.Key, rate => rate.Value);

            if (!filteredRates.Any())
            {
                return NotFound("Belirtilen para birimi için favori dövizler bulunamadı.");
            }

            return Ok(new
            {
                Base = result.Base,
                Date = result.Date,
                Rates = filteredRates
            });
        }

    }
}
