using OrderService.Primitives;

namespace OrderService.Entities
{
    public class OrderItem : Entity
    {
        private OrderItem()
           : base(Guid.NewGuid())
        {
        }

        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
