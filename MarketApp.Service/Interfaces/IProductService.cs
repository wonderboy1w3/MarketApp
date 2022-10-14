using MarketApp.Domain.Configurations;
using MarketApp.Domain.Entities;
using MarketApp.Service.DTOs;
using System.Linq.Expressions;

namespace MarketApp.Service.Interfaces;

public interface IProductService
{
    ValueTask<Product> AddAsync(ProductForCreationDto productDto);
    ValueTask<Product> UpdateAsync(long id, ProductForCreationDto productDto);
    ValueTask<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
    ValueTask<Product> GetAsync(Expression<Func<Product, bool>> expression);
    ValueTask<PaginationMetaData<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);
}
