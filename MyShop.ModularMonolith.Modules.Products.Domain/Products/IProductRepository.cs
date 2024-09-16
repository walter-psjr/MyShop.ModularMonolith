namespace MyShop.ModularMonolith.Modules.Products.Domain.Products;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
}