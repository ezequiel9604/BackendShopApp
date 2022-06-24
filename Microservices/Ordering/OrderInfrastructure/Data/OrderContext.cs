
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Ordering.OrderDomains.Entities;

namespace backendShopApp.Microservices.Ordering.OrderInfrastructure.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options)
        : base(options)
    {

    }

    public DbSet<Order>? Orders { get; set; }    
    public DbSet<Purchase>? Purchases { get; set; }
    public DbSet<Status>? Statuses { get; set; }

}