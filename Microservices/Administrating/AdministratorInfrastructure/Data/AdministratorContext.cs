
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Administrating.AdministratorDomains.Entities;

namespace backendShopApp.Microservices.Administrating.AdministratorInfrastructure.Data;

public class AdministratorContext : DbContext
{
    public AdministratorContext(DbContextOptions<AdministratorContext> options)
        : base(options)
    {

    }

    public DbSet<Administrator>? Administrators { get; set; }

}