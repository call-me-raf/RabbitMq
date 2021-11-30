using Contracts.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerOrder
{
    public class OrderCreated : IConsumer<IOrderCreated>
    {
        public Task Consume(ConsumeContext<IOrderCreated> context)
        {
            return Console.Out.WriteLineAsync($"Creating new order: {context.Message.OrderId}");
        }
    }
}
