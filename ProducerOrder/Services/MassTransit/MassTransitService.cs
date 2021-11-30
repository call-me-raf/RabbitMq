using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Definition;
using System;
using Contracts;
using ProducerOrder.Services;

namespace WebApp.Services
{
    /// <summary>
    /// MassTransit configurations for ASP.NET Core
    /// </summary>
    public class MassTransitService
    {
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var massTransitSection = configuration.GetSection("MassTransit");
            var url = massTransitSection.GetValue<string>("Url");
            var host = massTransitSection.GetValue<string>("Host");
            var userName = massTransitSection.GetValue<string>("UserName");
            var password = massTransitSection.GetValue<string>("Password");
            if (massTransitSection == null || url == null || host == null)
            {
                throw new NullReferenceException("Section 'mass-transit' configuration settings are not found in appSettings.json");
            }

            services.AddMassTransit(x =>
            {
                x.SetSnakeCaseEndpointNameFormatter();

                x.AddBus(busFactory =>
                {
                    var bus = Bus.Factory.CreateUsingRabbitMq((cfg) =>
                    {
                        cfg.Host($"rabbitmq://{Constants.RabbitMqUrl}/{Constants.RabbitMqHost}", configurator =>
                        {
                            configurator.Username(Constants.RabbitMqUserName);
                            configurator.Password(Constants.RabbitMqPassword);
                        });

                        cfg.ClearMessageDeserializers();
                        cfg.UseRawJsonSerializer();
                        //cfg.UseHealthCheck(busFactory);
                        cfg.ConfigureEndpoints(busFactory, SnakeCaseEndpointNameFormatter.Instance);

                        //add queue
                        cfg.ReceiveEndpoint(Constants.NotificationQueueNameOrder, q =>
                        {
                            q.Consumer<OrderCreated>();
                            q.Consumer<OrderUpdated>();
                        });
                    });
                    return bus;
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}