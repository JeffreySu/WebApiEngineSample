using Microsoft.AspNetCore.Authorization;
using Senparc.CO2NET;
using Senparc.CO2NET.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiSample
{
    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [ApiBind("WeatherForecast", "MyApi")]
        [Authorize]
        public WeatherForecast GetWeatherForecast(int index)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }

    [ApiBind("ClassCoverAttribute", "MyApi")]
    public class WeatherService2
    {
        public string GetWeatherForecast(string str)
        {
            return "the parameter value is :" + str;
        }

        [ApiBind(ApiRequestMethod = ApiRequestMethod.Get)]
        public string GetWeatherForecastCopy(string str)
        {
            return "the parameter value is :" + str;
        }

        public static string GetWeatherForecastCopyStatic(string str)
        {
            return "[static method]the parameter value is :" + str;
        }
    }
}
