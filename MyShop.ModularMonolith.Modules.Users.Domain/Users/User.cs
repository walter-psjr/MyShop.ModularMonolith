namespace MyShop.ModularMonolith.Modules.Users.Domain.Users;

public class User
{
    public User(Guid id, string userName)
    {
        Id = id;
        UserName = userName;
        Active = false;
    }

    public Guid Id { get; }
    public string UserName { get; }
    public bool Active { get; }
}