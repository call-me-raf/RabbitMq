using Contracts;
using MassTransit;
using GreenPipes;
using System;

namespace ConsumerOrder
{
    class Program
    {
        static void Main(string[] args)
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

                        //add queue
                        cfg.ReceiveEndpoint(Constants.NotificationQueueNameOrder, q =>
                        {
                            q.Consumer<OrderCreated>();
                            q.Consumer<OrderUpdated>();
                        });
                    });

            bus.StartAsync();
            Console.WriteLine("Listening for orders...");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}