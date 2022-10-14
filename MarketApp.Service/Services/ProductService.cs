using AutoMapper;
using MarketApp.Data.IRepositories;
using MarketApp.Domain.Configurations;
using MarketApp.Domain.Entities;
using MarketApp.Service.DTOs;
using MarketApp.Service.Exceptions;
using MarketApp.Service.Extensions;
using MarketApp.Service.Interfaces;
using System.Linq.Expressions;

namespace MarketApp.Service.Services;

#pragma warning disable
public class ProductService : IProductService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<Product> AddAsync(ProductForCreationDto productDto)
    {
        var product =
            await this.unitOfWork.Products.GetAsync(product => product.ItemName.Equals(productDto.ItemName));

        if (product is not null)
            throw new CustomException(400, "Product already exists");

        var mappedProduct = this.mapper.Map<Product>(productDto);
        mappedProduct.Create();

        var result = await this.unitOfWork.Products.AddAsync(mappedProduct);
        await this.unitOfWork.SaveChangesAsync();

        return result;
    }

    public async ValueTask<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
    {
        var product = await this.unitOfWork.Products.GetAsync(expression);
        if (product is null)
            throw new CustomException(404, "Product not found");

        product.Delete();
        await this.unitOfWork.Products.DeleteAsync(expression);
        await this.unitOfWork.SaveChangesAsync();

        return true;
    }

    public async ValueTask<PaginationMetaData<Product>> GetAllAsync(
        PaginationParams @params,
        Expression<Func<Product, bool>> expression = null)
    {
        return this.unitOfWork.Products.GetAll(expression).ToPagedList(@params);
    }

    public async ValueTask<Product> GetAsync(Expression<Func<Product, bool>> expression)
    {
        var product = await this.unitOfWork.Products.GetAsync(expression);
        if (product is null)
            throw new CustomException(404, "Product not found");

        return product;
    }

    public async ValueTask<Product> UpdateAsync(long id, ProductForCreationDto productDto)
    {
        var product = await this.unitOfWork.Products.GetAsync(product => product.Id.Equals(id));
        if (product is null)
            throw new CustomException(404, "Product not found");

        var mappedProduct = mapper.Map(productDto, product);
        mappedProduct.Update();

        var result = await this.unitOfWork.Products.UpdateAsync(mappedProduct);
        await this.unitOfWork.SaveChangesAsync();

        return result;
    }
}
