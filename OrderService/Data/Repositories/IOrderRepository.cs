using OrderService.DTOs;
using OrderService.Entities;

namespace OrderService.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetOrderByIdAsync(Guid id);

        void CreateOrder(Order order);

        Task<bool> SaveChangesAsync();
    }
}
