
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;

namespace backendShopApp.Microservices.Commenting.CommentInfrastructure.Data;

public class CommentContext : DbContext
{

    public CommentContext(DbContextOptions<CommentContext> options)
        : base(options)
    {

    }

    public DbSet<Comment>? Comments { get; set; }

}
