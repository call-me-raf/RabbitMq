using Contracts.Interfaces;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ProducerOrder.Services
{
    public class OrderUpdated : IConsumer<IOrderUpdated>
    {
        public Task Consume(ConsumeContext<IOrderUpdated> context)
        {
            return Task.CompletedTask;
        }
    }
}
