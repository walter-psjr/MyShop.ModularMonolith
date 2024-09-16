using Microsoft.EntityFrameworkCore;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.EntityTypeConfigurations;

namespace MyShop.ModularMonolith.Modules.Users.Infrastructure;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");

        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }
}