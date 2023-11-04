using Contracts;
using OrderService.DTOs;

namespace OrderService.Services
{
    public interface IProductService
    {
        public Task<List<ProductAvailabilityResult>> GetProductsAvailabilityAsync(List<OrderItemDto> orderItems);
    }
}
