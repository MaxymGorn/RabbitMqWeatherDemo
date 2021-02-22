using MediatR;
using Rectangle.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Messaging.Send.Sender;

namespace Weather.Service.Handlers
{
    public class AddWeatherHandler : IRequestHandler<AddWeatherCommand, Unit>
    {
        private readonly IWeatherSender weatherSender;
        public AddWeatherHandler(IWeatherSender weatherSender)
        {
            this.weatherSender = weatherSender;
        }
        public Task<Unit> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
        {
            weatherSender.SendWeather(request.WeatherForecastDto);
            return Task.FromResult(new Unit());
        }
    }
}
