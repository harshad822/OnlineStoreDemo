using OnlineStore.API.Data.Entity.DbSet;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.API.Data.Entity;
public class OnlineStoreDbContext: DbContext
{
    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
          : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}

