using MassTransit;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Products.Application;

public class UserCreatedDomainEventConsumer : IConsumer<UserCreatedDomainEvent>
{
    public Task Consume(ConsumeContext<UserCreatedDomainEvent> context)
    {
        Console.WriteLine($"User {context.Message.UserId} created!!!");

        return Task.CompletedTask;
    }
}