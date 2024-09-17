using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.ModularMonolith.Modules.Users.Application;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.Repositories;

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
        
        services.AddMediatR(mediatRConfiguration =>
        {
            mediatRConfiguration.RegisterServicesFromAssemblies(Assembly.Load("MyShop.ModularMonolith.Modules.Users.Application"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}