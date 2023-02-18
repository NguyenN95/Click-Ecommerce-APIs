using Click.common;
using Microsoft.EntityFrameworkCore;

namespace Click.product;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
    }

}