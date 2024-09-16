using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyShop.ModularMonolith.Modules.Products.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddProductsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductContext>((serviceProvider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MyShopDB"), x =>
            {
                x.MigrationsAssembly(typeof(ProductContext).Assembly.FullName);
                x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "products");
            });
        });

        return services;
    }
}