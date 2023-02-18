namespace Click.product;

public static class ProductGroupRoute
{
    public static RouteGroupBuilder MapProductsRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetProductsAsync);
        group.MapGet("/{id}", GetProductAsync);
        group.MapGet("/brands", GetProductBrandsAsync);
        group.MapGet("/types", GetProductTypesAsync);
        return group;
    }

    private static async Task<IResult> GetProductTypesAsync(IProductRepository productRepository)
    {
        var types = await productRepository.GetProductTypesAsync();
        return Results.Ok(types);
    }

    private static async Task<IResult> GetProductBrandsAsync(IProductRepository productRepository)
    {
        var brands = await productRepository.GetProductBrandsAsync();
        return Results.Ok(brands);
    }

    private static async Task<IResult> GetProductsAsync(IProductRepository productRepository)
    {
        var products = await productRepository.GetProductsAsync();
        return Results.Ok(products);
    }

    private static async Task<IResult> GetProductAsync(IProductRepository productRepository, int id)
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