using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DBRepository.Enums;

namespace DBRepository.Models
{
    public class OrderSaga
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        [Key]
        public Guid CorrelationId { get; set; }
        public string Version { get; set; }
        public short CurrentState { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime? ShippedDate { get; set; }
        public OrderSagaType Type { get; set; }
        public ICollection<OrderSagaItem> OrderSagaItems { get; set; }
    }
}
