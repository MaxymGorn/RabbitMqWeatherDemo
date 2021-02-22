using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Messaging.Send.Sender
{
    public interface IWeatherSender
    {
        public void SendWeather(WeatherForecastDto weatherForecastDto);
    }
}
