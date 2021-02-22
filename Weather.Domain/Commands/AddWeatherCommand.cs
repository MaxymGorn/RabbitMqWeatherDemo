using Newtonsoft.Json;
using Rectangle.Domain.Commands;
using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Rectangle.Domain.Commands
{
    public class AddWeatherCommand : CommandBaseBackGround
    {
        public AddWeatherCommand()
        {

        }
        [JsonConstructor]
        public AddWeatherCommand(WeatherForecastDto weatherForecastDto)
        {
            this.WeatherForecastDto = weatherForecastDto;
        }
        [Required]
        [JsonProperty("WeatherForecastDto")]
        public WeatherForecastDto WeatherForecastDto { get; set; }
    }
}
