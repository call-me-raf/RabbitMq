using DBRepository.Enums;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderSaga order);
        Task<List<OrderSaga>> GetOrders();
        Task<OrderSaga> GetOrder(Guid orderId);
        Task UpdateOrder(Guid orderId, OrderSagaType orderSagaType);
        Task DeleteOrder(Guid orderId);

    }
}
