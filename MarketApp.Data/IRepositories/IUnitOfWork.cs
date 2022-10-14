using MarketApp.Domain.Entities;
using MarketApp.Domain.Entities.Users;

namespace MarketApp.Data.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }
    IRepository<User> Users { get; }

    ValueTask SaveChangesAsync();
}