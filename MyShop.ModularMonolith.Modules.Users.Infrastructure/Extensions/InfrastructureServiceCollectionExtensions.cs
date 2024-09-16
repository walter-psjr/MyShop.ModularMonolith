using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyShop.ModularMonolith.Modules.Users.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserContext>((serviceProvider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MyShopDB"), x =>
            {
                x.MigrationsAssembly(typeof(UserContext).Assembly.FullName);
                x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "users");
            });
        });

        return services;
    }
}