using MarketApp.Data.DbContexts;
using MarketApp.Data.IRepositories;
using MarketApp.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarketApp.Data.Repositories;

#pragma warning disable
public class Repository<TSource> : IRepository<TSource> where TSource : Auditable
{
    protected readonly AppDbContext dbContext;
    protected readonly DbSet<TSource> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TSource>();
    }

    public async ValueTask<TSource> AddAsync(TSource entity)
    {
        var entryEntity = await this.dbSet.AddAsync(entity);

        return entryEntity.Entity;
    }

    public async ValueTask DeleteAsync(Expression<Func<TSource, bool>> expression)
    {
        var entryEntity = await GetAsync(expression);

        this.dbSet.Remove(entryEntity);
    }

    public IQueryable<TSource> GetAll(
        Expression<Func<TSource, bool>> expression = null,
        string include = null,
        bool isTracking = true)
    {
        IQueryable<TSource> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

        if (!string.IsNullOrEmpty(include))
            query = query.Include(include);

        if (!isTracking)
            query = query.AsNoTracking();

        return query;
    }

    public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string include = null)
        => await GetAll(expression, include).FirstOrDefaultAsync();

    public async ValueTask<TSource> UpdateAsync(TSource entity)
        => this.dbSet.Update(entity).Entity;
}

