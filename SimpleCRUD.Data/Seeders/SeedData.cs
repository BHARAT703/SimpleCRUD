using SimpleCRUD.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRUD.Data.Seeders
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product() { Name = "Nokia 7 Plus", Description = "a great phone with low price", Price = 25000m, CreationTime = DateTime.UtcNow, CreatorUserId = 1 },
                    new Product() { Name = "Lenovo yoga series", Description = "laptops for students, professionals and gamers.", Price = 56000m, CreationTime = DateTime.UtcNow, CreatorUserId = 1 },
                    new Product() { Name = "SD Cricket Bats", Description = "bat made with pure wood.", Price = 1200m, CreationTime = DateTime.UtcNow, CreatorUserId = 1 }
                    );

                await context.SaveChangesAsync();
            }

            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order() { Name = "Order - 1105: Nokia mobile phone", Shipped = true, Address = "22, New Raipur Area", City = "Raipur", ProductId = context.Products.Where(m => m.Name.Contains("Nokia")).FirstOrDefault().Id });

                await context.SaveChangesAsync();
            }
        }
    }
}
