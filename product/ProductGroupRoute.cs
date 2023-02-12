using Click.common;
using Microsoft.EntityFrameworkCore;

namespace Click.product;

public static class ProductGroupRoute
{
    public static RouteGroupBuilder MapProductRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetProducts);
        group.MapGet("/{id}", GetProduct);
        return group;
    }

    public static async Task<IResult> GetProducts(StoreContext context)
    {
        var products = await context.Products.AsNoTracking().ToListAsync();
        return Results.Ok(products);
    }

    public static async Task<IResult> GetProduct(StoreContext context, int id)
    {
        var product = await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return Results.NotFound(new
            {
                error = "Product not found"
            });

        return Results.Ok(product);
    }
}