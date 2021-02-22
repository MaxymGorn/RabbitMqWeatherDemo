using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Rectangle.Domain.Commands;
using Rectangle.Domain.Dtos;
using Rectangle.Domain.PipelineBehaviours;
using System.Collections.Generic;
using System.Reflection;
using Weather.Domain.Queries;
using Weather.Service.Dxos;
using Weather.Service.Handlers;
using Weather.Service.Services;
using WeatherApi.Messaging.Receiver.Receiver;
using WeatherApi.Messaging.Send.Options;
using WeatherApi.Messaging.Send.Sender;
using WebApplication2.Interfaces;
using WebApplication2.Storage;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddOptions();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
            });
            services.AddSingleton<IWeatherDxos, WeatherDxos>();
            services.AddSingleton<IWeatherSender, WeatherSender>();
            services.AddSingleton<IMemoryWeatherStorage, MemoryWeatherStorage>();
            services.AddSingleton<IWeatherAddService, WeatherAddService>();

            services.AddTransient<IRequestHandler<AddWeatherCommand, Unit>, AddWeatherHandler>();
            services.AddTransient<IRequestHandler<GetWeatherQuery, List<WeatherForecastDto>>, GetWeatherHandler>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            IConfigurationSection serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            RabbitMqConfiguration serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);
            services.AddHostedService<AddWeatherReceiver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
