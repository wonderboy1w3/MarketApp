using MarketApp.Data.DbContexts;
using MarketApp.Domain.Entities;
using MarketApp.Domain.Entities.Users;
using MarketApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Mvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Products.Any())
                    return;

                context.Products.AddRange(
                    new Product
                    {
                        ItemName = "HDD 1TB",
                        Quantity = 55,
                        Price = (decimal)74.09
                    }, 
                    new Product
                    {
                        ItemName = "HDD SSD 512GB ",
                        Quantity = 102,
                        Price = (decimal)190.99
                    }, 
                    new Product
                    {
                        ItemName = "RAM DDR4 16GB",
                        Quantity = 47,
                        Price = (decimal)80.32
                    }
                );

                if (context.Users.Any())
                    return;

                context.Users.AddRange(
                    new User
                    {
                        Username = "admin",
                        Password = "12345",
                        Role = UserRole.Admin
                    },
                    new User
                    {
                        Username = "user",
                        Password = "123455",
                        Role = UserRole.User
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
