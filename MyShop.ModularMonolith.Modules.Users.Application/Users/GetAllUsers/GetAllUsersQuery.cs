using MediatR;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Users.Application.Users.GetAllUsers;

public record GetAllUsersQuery() : IRequest<List<User>>;