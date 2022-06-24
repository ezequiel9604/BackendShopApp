
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Iteming.ItemDomains.Entities;

namespace backendShopApp.Microservices.Iteming.ItemInfrastructure.Data;

public class ItemContext : DbContext
{
    public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
    {

    }

    public DbSet<Item>? Items { get; set; }
    public DbSet<Image>? Images { get; set; }
    public DbSet<SubItem>? SubItems { get; set; }
    public DbSet<Brand>? Brands { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<SubCategory>? SubCategories { get; set; }

}