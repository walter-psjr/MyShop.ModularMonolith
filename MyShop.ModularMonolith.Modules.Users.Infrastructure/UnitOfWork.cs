using MyShop.ModularMonolith.Modules.Users.Application;

namespace MyShop.ModularMonolith.Modules.Users.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly UserContext _userContext;

    public UnitOfWork(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task CommitAsync()
    {
        await _userContext.SaveChangesAsync();
    }
}