namespace OrderService.DTOs
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
