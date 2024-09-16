using MassTransit;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Users.Application;

public class ProductCreatedDomainEventConsumer : IConsumer<ProductCreatedDomainEvent>
{
    public Task Consume(ConsumeContext<ProductCreatedDomainEvent> context)
    {
        Console.WriteLine($"Product {context.Message.ProductId} created!!!");

        return Task.CompletedTask;
    }
}