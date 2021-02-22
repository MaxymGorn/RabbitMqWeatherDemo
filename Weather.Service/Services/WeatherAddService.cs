using Rectangle.Domain.Dtos;
using WebApplication2.Interfaces;

namespace Weather.Service.Services
{
    public class WeatherAddService: IWeatherAddService
    {
        private readonly IMemoryWeatherStorage memoryWeatherStorage;
        public WeatherAddService(IMemoryWeatherStorage memoryWeatherStorage)
        {
            this.memoryWeatherStorage = memoryWeatherStorage;
        }
        public void AddWeather(WeatherForecast weatherForecast)
        {
            memoryWeatherStorage.Add(weatherForecast);
        }
    }
}
