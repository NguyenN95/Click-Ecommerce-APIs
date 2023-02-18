namespace Click.product;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync();

    Task<Product?> GetProductByIdAsync(int id);

    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}