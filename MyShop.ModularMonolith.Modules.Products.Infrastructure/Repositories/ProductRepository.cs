using Microsoft.EntityFrameworkCore;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _productContext;

    public ProductRepository(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _productContext.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _productContext.Products.AddAsync(product);
    }
}