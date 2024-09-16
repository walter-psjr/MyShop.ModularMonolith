using MyShop.ModularMonolith.Modules.Products.Application;

namespace MyShop.ModularMonolith.Modules.Products.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductContext _productContext;

    public UnitOfWork(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public async Task CommitAsync()
    {
        await _productContext.SaveChangesAsync();
    }
}