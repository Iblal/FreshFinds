using OrderService.Primitives;

namespace OrderService.Entities
{
    public class Order : Entity
    {
        private Order()
            : base(Guid.NewGuid())
        {
        }

        public Guid CustomerId { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
