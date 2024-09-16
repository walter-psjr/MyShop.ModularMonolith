using MyShop.ModularMonolith.Modules.Products.Api.Controllers;
using MyShop.ModularMonolith.Modules.Products.Infrastructure.Extensions;
using MyShop.ModularMonolith.Modules.Users.Api.Controllers;
using MyShop.ModularMonolith.Modules.Users.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(UsersController).Assembly)
    .AddApplicationPart(typeof(ProductsController).Assembly);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddProductsInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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