using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IMemoryWeatherStorage
    {
        public void Add(WeatherForecast weatherForecastElement);
        public IEnumerable<WeatherForecast> Get();
    }
}
