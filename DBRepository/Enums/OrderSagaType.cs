using System;
using System.Collections.Generic;
using System.Text;

namespace DBRepository.Enums
{
    public enum OrderSagaType
    {
        Initial,
        AwaitingPacking,
        Packed,
        Shipped
    }
}
