using Hangfire.MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }
        protected void CommandAsyncBackGround(IRequest command)
        {
            _mediator.Enqueue(Guid.NewGuid().ToString(), command);
        }
        protected ActionResult OkBase(object value)
        {
            return Ok(value);
        }
        protected ActionResult ErrorBase(int statusCode, object value)
        {
            return StatusCode(statusCode, value);
        }
    }
}
