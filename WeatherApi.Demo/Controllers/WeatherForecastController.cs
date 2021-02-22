using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rectangle.Domain.Commands;
using Rectangle.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Weather.Domain.Queries;
using WeatherApi.Controllers;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator) : base(mediator)
        {
            this.logger = logger;
        }
        /// <summary>
        /// Get the number of all possible rectangles
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("AddWeather")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CountRectanglesAsync(AddWeatherCommand command)
        {
            try
            {
                await CommandAsync(command);
                return OkBase(new { Message = HttpStatusCode.OK });
            }
            catch (Exception exception)
            {
                return ErrorBase(StatusCodes.Status500InternalServerError, new { Error = exception.StackTrace });
            }
        }

        [HttpGet("GetWeather")]
        public async Task<ActionResult> GetWeather([FromQuery] GetWeatherQuery query)
        {
            try
            {
                return OkBase(new { List = await QueryAsync(query) });
            }
            catch (Exception exception)
            {
                return ErrorBase(StatusCodes.Status500InternalServerError, new { Error = exception.StackTrace });
            }
        }
    }
}
