using MassTransit;
using MyShop.ModularMonolith.Modules.Products.Api.Controllers;
using MyShop.ModularMonolith.Modules.Products.Application;
using MyShop.ModularMonolith.Modules.Products.Application.GetAllProducts;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;
using MyShop.ModularMonolith.Modules.Products.Infrastructure;
using MyShop.ModularMonolith.Modules.Products.Infrastructure.Extensions;
using MyShop.ModularMonolith.Modules.Users.Api.Controllers;
using MyShop.ModularMonolith.Modules.Users.Api.Extensions;
using MyShop.ModularMonolith.Modules.Users.Application;
using MyShop.ModularMonolith.Modules.Users.Application.Users.GetAllUsers;
using MyShop.ModularMonolith.Modules.Users.Infrastructure;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddUserModuleControllers()
    .AddApplicationPart(typeof(ProductsController).Assembly);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddProductsInfrastructure(builder.Configuration);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(typeof(GetAllProductsQuery).Assembly, typeof(GetAllUsersQuery).Assembly);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddEntityFrameworkOutbox<ProductContext>(c =>
    {
        c.UsePostgres();
        
        c.UseBusOutbox();
    });
    
    configurator.AddEntityFrameworkOutbox<UserContext>(c =>
    {
        c.UsePostgres();
        
        c.UseBusOutbox();
    });
    
    configurator.AddConsumer<ProductCreatedDomainEventConsumer>();

    configurator.AddConsumer<UserCreatedDomainEventConsumer>();
    
    // configurator.AddConfigureEndpointsCallback((context, name, cfg) =>
    // {
    //     cfg.UseEntityFrameworkOutbox<ProductContext>(context);
    //     cfg.UseEntityFrameworkOutbox<UserContext>(context);
    // });
    
    configurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("127.0.0.1", "/", h =>
        {
            h.Username("myshopuser");
            h.Password("myshoppassword");
        });
        
        cfg.ReceiveEndpoint("products", c =>
        {
            c.UseEntityFrameworkOutbox<ProductContext>(context);
            
            c.ConfigureConsumer<ProductCreatedDomainEventConsumer>(context);
        });
        
        cfg.ReceiveEndpoint("users", c =>
        {
            c.UseEntityFrameworkOutbox<UserContext>(context);
            
            c.ConfigureConsumer<UserCreatedDomainEventConsumer>(context);
        });
        
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

await app.RunAsync();