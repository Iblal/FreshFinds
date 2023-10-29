using Microsoft.EntityFrameworkCore;
using OrderService.Entities;

namespace OrderService.Data
{
    public class OrderDatabaseContext : DbContext
    {
        public OrderDatabaseContext(DbContextOptions<OrderDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } 

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
