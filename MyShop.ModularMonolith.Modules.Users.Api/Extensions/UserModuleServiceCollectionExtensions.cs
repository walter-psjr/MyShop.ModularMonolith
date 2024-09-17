using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.Extensions;

namespace MyShop.ModularMonolith.Modules.Users.Api.Extensions;

public static class UserModuleServiceCollectionExtensions
{
    public static IMvcBuilder AddUserModuleControllers(this IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(UserModuleServiceCollectionExtensions).Assembly);

        return builder;
    }
    
    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }
}