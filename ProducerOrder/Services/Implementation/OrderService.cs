using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Enums;
using DBRepository.Interfaces;
using DBRepository.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        public OrderService(IOrderRepository repository)
        {
            this.orderRepository = repository;
        }
        public async Task AddOrder(OrderSaga order)
        {
            await orderRepository.AddOrder(order);
        }

        public async Task<OrderSaga> GetOrder(Guid orderId)
        {
            return await orderRepository.GetOrder(orderId);
        }

        public async Task<List<OrderSaga>> GetOrders()
        {
            return await orderRepository.GetOrders();
        }

        public async Task UpdateOrder(Guid orderId, OrderSagaType orderSagaType)
        {
            await orderRepository.UpdateOrder(orderId, orderSagaType);
        }
        public async Task DeleteOrder(Guid orderId)
        {
            await orderRepository.DeleteOrder(orderId);
        }
    }
}
