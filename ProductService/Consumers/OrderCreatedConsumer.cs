using Contracts;
using MassTransit;

namespace ProductService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            return null;
        }
    }
}
