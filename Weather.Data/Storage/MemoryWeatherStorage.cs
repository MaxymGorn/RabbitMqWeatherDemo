using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;

namespace WebApplication2.Storage
{
    public class MemoryWeatherStorage: IMemoryWeatherStorage
    {
        private readonly IList<WeatherForecast> weatherForecasts;
        public MemoryWeatherStorage()
        {
            weatherForecasts = new List<WeatherForecast>();
        }

        public void Add(WeatherForecast weatherForecastElement)
        {
            weatherForecasts.Add(weatherForecastElement);
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return weatherForecasts;
        }
    }
}
