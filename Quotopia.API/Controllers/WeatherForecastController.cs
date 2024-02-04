using Microsoft.AspNetCore.Mvc;
using Quotopia.API.Models;
using Quotopia.API.Services;

namespace Quotopia.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IQuoteService _quoteService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<Quote>> Get()
        {
            return await _quoteService.GetQuotes();
        }
    }
}
