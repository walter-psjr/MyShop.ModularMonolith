namespace MyShop.ModularMonolith.Modules.Users.Application;

public interface IUnitOfWork
{
    Task CommitAsync();
}