using Rectangle.Domain.Dtos;
using Rectangle.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Queries
{
    public class GetWeatherQuery: QueryBase<List<WeatherForecastDto>>
    {
    }
}
