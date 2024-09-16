namespace MyShop.ModularMonolith.Modules.Products.Application;

public interface IUnitOfWork
{
    Task CommitAsync();
}