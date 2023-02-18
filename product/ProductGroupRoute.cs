namespace Click.product;

public static class ProductGroupRoute
{
    public static RouteGroupBuilder MapProductsRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetProducts);
        group.MapGet("/{id}", GetProduct);
        return group;
    }

    public static async Task<IResult> GetProducts(IProductRepository productRepository)
    {
        var products = await productRepository.GetProductsAsync();
        return Results.Ok(products);
    }

    public static async Task<IResult> GetProduct(IProductRepository productRepository, int id)
    {
        var product = await productRepository.GetProductByIdAsync(id);

        if (product == null)
            return Results.NotFound(new
            {
                error = "Product not found"
            });

        return Results.Ok(product);
    }
}