using Microsoft.EntityFrameworkCore;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task AddAsync(User user)
    {
        await _userContext.Users.AddAsync(user);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userContext.Users.ToListAsync();
    }
}