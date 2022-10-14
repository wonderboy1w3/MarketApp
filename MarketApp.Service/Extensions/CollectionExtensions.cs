using MarketApp.Domain.Configurations;

namespace MarketApp.Service.Extensions;

public static class CollectionExtension
{
    public static PaginationMetaData<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        var count = source.Count();
        var items = source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize).ToList();

        return new PaginationMetaData<T>(items, count, @params.PageIndex, @params.PageSize);
    }
}