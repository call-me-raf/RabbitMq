using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBRepository.Models
{
    public class OrderSagaItem
    {
        [Key]
        public int id { get; set; }
        public Guid OrderCorrelationId { get; set; }
        /// <summary>
        /// Stock Keeping Unit
        /// </summary>
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
