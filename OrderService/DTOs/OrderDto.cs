﻿using Azure.Core.Pipeline;

namespace OrderService.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
