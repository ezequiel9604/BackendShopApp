
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Clienting.ClientInfrastructure.Data;

public class ClientContext : DbContext
{

    public ClientContext(DbContextOptions<ClientContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Client>()
            .HasIndex(x => x.Email)
            .IsUnique();
    }

    public DbSet<Client>? Clients { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Phone>? Phones { get; set; }
    public DbSet<Appearance>? Appearances { get; set; }
    public DbSet<Language>? Languages { get; set; }
    public DbSet<State>? States { get; set; }
    public DbSet<Currancy>? Currancies { get; set; }
    public DbSet<ClientType>? Types { get; set; }
    public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
    public DbSet<WishList>? WishLists { get; set; }
    public DbSet<Wallet>? Wallets { get; set; }

}
