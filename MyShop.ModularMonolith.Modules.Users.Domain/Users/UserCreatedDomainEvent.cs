namespace MyShop.ModularMonolith.Modules.Users.Domain.Users;

public record UserCreatedDomainEvent(Guid EventId, Guid UserId);