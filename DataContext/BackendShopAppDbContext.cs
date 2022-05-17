using Microsoft.EntityFrameworkCore;

namespace backendShopApp.DataContext;

public class BackendShopAppDbContext : DbContext 
{

    public BackendShopAppDbContext(DbContextOptions<BackendShopAppDbContext> options)
        : base(options)
    {
        
    }

    // database tables

}