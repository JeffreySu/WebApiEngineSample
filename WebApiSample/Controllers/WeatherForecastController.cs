using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherForecastController(WeatherService weatherService)
        {
            this._weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherService.GetWeatherForecasts();
        }
    }
}
