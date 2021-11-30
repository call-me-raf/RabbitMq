using Contracts.Interfaces;
using DBRepository.Models;
using System;

namespace ProducerOrder.Models
{
    public class UpdateOrderModel : OrderSaga, IOrderUpdated
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
