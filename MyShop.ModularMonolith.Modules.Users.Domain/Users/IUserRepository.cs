namespace MyShop.ModularMonolith.Modules.Users.Domain.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync();
}