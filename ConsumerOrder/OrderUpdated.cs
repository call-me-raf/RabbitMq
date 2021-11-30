using Contracts.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerOrder
{
    public class OrderUpdated : IConsumer<IOrderUpdated>
    {
        public Task Consume(ConsumeContext<IOrderUpdated> context)
        {
            return Console.Out.WriteLineAsync($"Order shipped: {context.Message.OrderId}. Current Status: {context.Message.OrderStatus}");

        }
    }
}
