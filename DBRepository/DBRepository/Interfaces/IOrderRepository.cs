using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Enums;
using DBRepository.Models;

namespace DBRepository.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(OrderSaga order);
        Task<List<OrderSaga>> GetOrders();
        Task<OrderSaga> GetOrder(Guid orderId);
        Task UpdateOrder(Guid orderId, OrderSagaType orderSagaType);
        Task DeleteOrder(Guid orderId);

    }
}
