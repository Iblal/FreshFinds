using Contracts;
using MassTransit;
using ProductService.Data.Repositories;

namespace ProductService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly IProductRepository _productRepository;

        public OrderCreatedConsumer(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            foreach(var item in context.Message.OrderedProducts)
            {
                var product = _productRepository.GetProduct(item.ProductId);

                if (product is null) throw new NullReferenceException();

                await _productRepository.ReduceStock(item.ProductId, item.Quantity);
            }
        }
    }
}
