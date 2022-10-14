using MarketApp.Data.IRepositories;
using MarketApp.Data.Repositories;
using MarketApp.Service.Interfaces;
using MarketApp.Service.Services;

namespace MarketApp.Mvc.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
           // services.AddScoped<IUserService, UserService>();
        }
    }
}
