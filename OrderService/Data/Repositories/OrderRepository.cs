using OrderService.DTOs;
using OrderService.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDatabaseContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(OrderDatabaseContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
