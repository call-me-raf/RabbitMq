using Contracts.Interfaces;
using DBRepository.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProducerOrder.Services
{
    public class OrderCreated : IConsumer<IOrderCreated>
    {
        public Task Consume(ConsumeContext<IOrderCreated> context)
        {
            return Task.CompletedTask;
        }
    }
}