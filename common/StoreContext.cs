using Click.product;
using Microsoft.EntityFrameworkCore;

namespace Click.common;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}