using System;
using System.Collections.Generic;

namespace Contracts
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }

        public List<OrderedItem> OrderItems { get; set; }

        public OrderCreatedEvent(Guid orderId, List<OrderedItem> orderedItems)
        {
            OrderId = orderId;
            OrderItems = orderedItems;
        }
    }

    public class OrderedItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
