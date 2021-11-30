using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Enums;
using DBRepository.Interfaces;
using DBRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DBRepository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
        }

        public async Task AddOrder(OrderSaga order)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                try
                {
                    context.OrderSaga.Add(order);
                    await context.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public Task DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderSaga> GetOrder(Guid orderId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.OrderSaga.FirstOrDefaultAsync(x => x.CorrelationId == orderId);
            }
        }

        public async Task<List<OrderSaga>> GetOrders()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.OrderSaga.ToListAsync();
            }
        }

        public async Task UpdateOrder(Guid orderId, OrderSagaType orderSagaType)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var order = context.OrderSaga.FirstOrDefault(o => o.CorrelationId == orderId);
                order.CurrentState = (short)orderSagaType;
                order.UpdatedDate = DateTime.Now;

                await context.SaveChangesAsync();
            }
        }

    }
}
