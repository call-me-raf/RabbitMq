using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IOrderCreated
    {
        public Guid OrderId { get; set; }
    }
}
