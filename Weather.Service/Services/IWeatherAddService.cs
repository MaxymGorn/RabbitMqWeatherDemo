using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Services
{
    public interface IWeatherAddService
    {
        public void AddWeather(WeatherForecast weatherForecast);
    }
}
