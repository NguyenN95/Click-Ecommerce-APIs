namespace Click.product;

public static class ProductGroupRoute
{
    public static RouteGroupBuilder MapProductRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetProducts);
        group.MapGet("/{id}", GetProduct);
        return group;
    }

    public static IResult GetProducts()
    {
        return Results.Ok("This will print list of products");
    }

    public static IResult GetProduct(int id)
    {
        return Results.Ok($"This will print product with id {id}");
    }
}