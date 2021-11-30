using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public class OrderUpdated : IOrderUpdated
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
    }

    public interface IOrderUpdated
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
