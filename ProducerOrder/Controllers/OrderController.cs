using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBRepository.Models;
using DBRepository.Enums;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProducerOrder.Models;
using WebApp.Services.Interfaces;
using Contracts.Interfaces;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderController(IOrderService orderService, IPublishEndpoint publishEndpoint)
        {
            this.orderService = orderService;
            this.publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Добавление заказа в БД
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Route("addOrder")]
        [HttpPost]
        public async Task AddOrder(CreateNewOrderModel order)
        {
            await orderService.AddOrder(order);
            await publishEndpoint.Publish(order);
        }


        /// <summary>
        /// Получение заказов из БД
        /// </summary>
        /// <returns></returns>
        [Route("getOrders")]
        [HttpGet]
        public async Task<List<OrderSaga>> GetOrders()
        {
            return await orderService.GetOrders();
        }

        /// <summary>
        /// Обновление статуса заказа
        /// </summary>
        /// <param name="guid">Order Guid</param>
        /// <returns></returns>
        [Route("updateOrder")]
        [HttpPost]
        public async Task UpdateOrder(Guid guid)
        {
            var orderInfo = orderService.GetOrder(guid);
            await orderService.UpdateOrder(guid, orderInfo.Result.Type);

            string status = Enum.GetName(typeof(OrderSagaType), orderInfo.Result.Type);

            switch (orderInfo.Result.Type)
            {
                case OrderSagaType.AwaitingPacking:
                    await publishEndpoint.Publish(new OrderUpdated { OrderId = guid, OrderStatus = status });
                    break;
                case OrderSagaType.Packed:
                    await publishEndpoint.Publish(new OrderUpdated { OrderId = guid, OrderStatus = status });
                    break;
                case OrderSagaType.Shipped:
                    await publishEndpoint.Publish(new OrderUpdated { OrderId = guid, OrderStatus = status });
                    break;
                default:
                    break;
            }
        }
    }
}