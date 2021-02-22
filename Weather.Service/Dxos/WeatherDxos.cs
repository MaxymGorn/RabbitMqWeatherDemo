using AutoMapper;
using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Dxos
{
    public class WeatherDxos: IWeatherDxos
    {
        private readonly IMapper _mapper;

        public WeatherDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WeatherForecast, WeatherForecastDto>()
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.TemperatureC, opt => opt.MapFrom(src => src.TemperatureC))
                .ForMember(dst => dst.TemperatureF, opt => opt.MapFrom(src => src.TemperatureF))
                .ForMember(dst => dst.Summary, opt => opt.MapFrom(src => src.Summary));
            });
            _mapper = config.CreateMapper();
        }


        public List<WeatherForecastDto> MapListWeatherDto(IEnumerable<WeatherForecast> weatherForecasts)
        {
            List<WeatherForecast> result = weatherForecasts.ToList();
            return _mapper.Map<IEnumerable<WeatherForecast>, List<WeatherForecastDto>>(result);
        }
    }
}
