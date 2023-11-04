using MassTransit;
using ProductService.Data.Repositories;
using Contracts;

namespace ProductService.Consumers
{
    public class GetProductsAvailabilityConsumer : IConsumer<GetProductsAvailabilityRequest>
    {
        private readonly IProductRepository _productRepo;

        public GetProductsAvailabilityConsumer(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task Consume(ConsumeContext<GetProductsAvailabilityRequest> context)
        {
            var availabilityResults = new List<ProductAvailabilityResult>();

            foreach (var item in context.Message.Items)
            {
                var product = await _productRepo.GetProduct(item.ProductId);
                bool doesExist = product is not null;
                bool sufficientStock = doesExist && product.Stock >= item.Quantity;

                availabilityResults.Add(new ProductAvailabilityResult
                {
                    ProductId = item.ProductId,
                    DoesExist = doesExist,
                    SufficientStock = sufficientStock
                });
            }

            // Create and send the response message with the availability results.
            var response = new GetProductsAvailabilityResponse
            {
                Results = availabilityResults
            };

            await context.RespondAsync(response);
        }
    }
}
