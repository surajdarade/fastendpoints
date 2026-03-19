using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Seed {
    public static class DbSeeder {
        public static void Seed(ApplicationDbContext context) {
            if (context.Products.Any())
                return;

            var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Name = "Laptop", Price = 80000 },
            new() { Id = Guid.NewGuid(), Name = "Phone", Price = 30000 },
            new() { Id = Guid.NewGuid(), Name = "Headphones", Price = 2000 }
        };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
