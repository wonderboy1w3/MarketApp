using MarketApp.Domain.Commons;
using System.Linq.Expressions;

namespace MarketApp.Data.IRepositories;

public interface IRepository<TSource> where TSource : Auditable
{
    ValueTask<TSource> AddAsync(TSource entity);
    ValueTask<TSource> UpdateAsync(TSource entity);
    ValueTask DeleteAsync(Expression<Func<TSource, bool>> expression);
    ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string include = null);
    IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string include = null, bool isTracking = true);
}