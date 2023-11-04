using System;
using System.Collections.Generic;

namespace Contracts
{
    public class OrderCreated
    {
        public Guid OrderId { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
    }

    public class OrderedProduct
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

