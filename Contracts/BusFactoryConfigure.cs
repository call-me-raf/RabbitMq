using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Contracts
{
    public static class BusFactoryConfigure
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 var host = cfg.Host(new Uri($"rabbitmq://{Constants.RabbitMqUrl}/{Constants.RabbitMqHost}"), hst =>
                 {
                     hst.Username(Constants.RabbitMqUserName);
                     hst.Password(Constants.RabbitMqPassword);
                 });
               
                 registrationAction?.Invoke(cfg, host);
             });
        }
    }
}
