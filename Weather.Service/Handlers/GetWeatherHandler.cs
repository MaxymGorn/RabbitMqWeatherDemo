using MediatR;
using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Domain.Queries;
using Weather.Service.Dxos;
using WebApplication2.Interfaces;

namespace Weather.Service.Handlers
{
    public class GetWeatherHandler : IRequestHandler<GetWeatherQuery, List<WeatherForecastDto>>
    {
        private readonly IMemoryWeatherStorage memoryWeatherStorage;
        private readonly IWeatherDxos weatherDxos;
        public GetWeatherHandler(IMemoryWeatherStorage memoryWeatherStorage, IWeatherDxos weatherDxos)
        {
            this.memoryWeatherStorage = memoryWeatherStorage;
            this.weatherDxos = weatherDxos;
        }
        public Task<List<WeatherForecastDto>> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<WeatherForecast> listWeatherForecasts = memoryWeatherStorage.Get();
            List<WeatherForecastDto> listWeatherForecastsDto = weatherDxos.MapListWeatherDto(listWeatherForecasts);
            return Task.FromResult(listWeatherForecastsDto);
        }
    }
}
