using MassTransit;
using MyShop.ModularMonolith.Modules.Products.Api.Controllers;
using MyShop.ModularMonolith.Modules.Products.Application.GetAllProducts;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;
using MyShop.ModularMonolith.Modules.Products.Infrastructure.Extensions;
using MyShop.ModularMonolith.Modules.Users.Api.Controllers;
using MyShop.ModularMonolith.Modules.Users.Application;
using MyShop.ModularMonolith.Modules.Users.Application.Users.GetAllUsers;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(UsersController).Assembly)
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
    configurator.AddConsumer<ProductCreatedDomainEventConsumer>();
    
    configurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("127.0.0.1", "/", h =>
        {
            h.Username("myshopuser");
            h.Password("myshoppassword");
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