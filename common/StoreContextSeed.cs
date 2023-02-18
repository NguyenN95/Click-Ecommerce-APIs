using System.Text.Json;
using Click.product;

namespace Click.common;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText("./common/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            if (brands != null)
            {
                context.ProductBrands.AddRange(brands);
            }
        }

        if (!context.ProductTypes.Any())
        {
            var typesData = File.ReadAllText("./common/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

            if (types != null)
            {
                context.ProductTypes.AddRange(types);
            }
        }

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("./common/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products != null)
            {
                context.Products.AddRange(products);
            }
        }

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }
}