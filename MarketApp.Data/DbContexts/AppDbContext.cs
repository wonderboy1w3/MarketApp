using MarketApp.Domain.Entities;
using MarketApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }
}
