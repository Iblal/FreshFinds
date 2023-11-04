namespace OrderService.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public string CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
