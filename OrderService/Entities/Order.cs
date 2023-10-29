using OrderService.Primitives;

namespace OrderService.Entities
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _orderItems = new();

        private Order()
            : base(Guid.NewGuid())
        {
        }

        public string CustomerId { get; set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    }
}
