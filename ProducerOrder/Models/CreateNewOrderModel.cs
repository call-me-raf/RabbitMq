using Contracts.Interfaces;
using DBRepository.Models;
using System;

namespace ProducerOrder.Models
{
    public class CreateNewOrderModel : OrderSaga, IOrderCreated
    {
        public Guid OrderId { get; set; }
    }
}
