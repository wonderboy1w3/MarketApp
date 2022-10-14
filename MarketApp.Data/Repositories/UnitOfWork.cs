using MarketApp.Data.DbContexts;
using MarketApp.Data.IRepositories;
using MarketApp.Domain.Entities;
using MarketApp.Domain.Entities.Users;

namespace MarketApp.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;

        Products = new Repository<Product>(dbContext);
        Users = new Repository<User>(dbContext);
    }

    public IRepository<Product> Products { get; }
    public IRepository<User> Users { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask SaveChangesAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }
}
