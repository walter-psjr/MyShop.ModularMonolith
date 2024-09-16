using MediatR;

namespace MyShop.ModularMonolith.Modules.Users.Application.Users.CreateUser;

public record CreateUserCommand(string UserName) : IRequest<Unit>;