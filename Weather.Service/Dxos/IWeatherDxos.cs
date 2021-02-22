using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Dxos
{
    public interface IWeatherDxos
    {
        public List<WeatherForecastDto> MapListWeatherDto(IEnumerable<WeatherForecast> weatherForecasts);
    }
}
