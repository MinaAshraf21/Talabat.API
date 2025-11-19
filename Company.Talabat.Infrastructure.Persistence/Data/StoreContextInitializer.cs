using Company.Talabat.Domain.Contracts;
using Company.Talabat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Company.Talabat.Infrastructure.Persistence.Data
{
    internal class StoreContextInitializer(StoreContext _storeContext) : IStoreContextInitializer
    {
        public async Task InitializeAsync()
        {
            //it's better to check for pending migrations before calling Migrate method
            // the migrate method also checks for pending migrations internally but with extra overhead
            //var pendingMigrations = StoreContext.Database.GetPendingMigrations();

            // get all migrations that are defined in the project but not applied to the database yet
            // it can also check if the database exists or not
            var pendingMigrations = await _storeContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
                //this method will create the database if it does not exist and apply all migrations in case of any pending migrations
                //await StoreContext.Database.MigrateAsync();
                await _storeContext.Database.MigrateAsync();
        }

        public async Task SeedAsync()
        {
            if (!_storeContext.Brands.Any())
            {
                var brandsData = await File.ReadAllTextAsync("../Company.Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    await _storeContext.Brands.AddRangeAsync(brands);
                    await _storeContext.SaveChangesAsync();
                }
            }

            if (!_storeContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("../Company.Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                if (categories?.Count > 0)
                {
                    await _storeContext.Categories.AddRangeAsync(categories);
                    await _storeContext.SaveChangesAsync();
                }
            }

            if (!_storeContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Company.Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count > 0)
                {
                    await _storeContext.Products.AddRangeAsync(products);
                    await _storeContext.SaveChangesAsync();
                }
            }
        }
    }
}
