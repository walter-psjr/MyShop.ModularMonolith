using Microsoft.EntityFrameworkCore;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;
using MyShop.ModularMonolith.Modules.Products.Infrastructure.EntityTypeConfigurations;

namespace MyShop.ModularMonolith.Modules.Products.Infrastructure;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}