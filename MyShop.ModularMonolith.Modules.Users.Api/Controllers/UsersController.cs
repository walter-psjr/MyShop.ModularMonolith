using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyShop.ModularMonolith.Modules.Users.Application.Users.CreateUser;
using MyShop.ModularMonolith.Modules.Users.Application.Users.GetAllUsers;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Users.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        await _mediator.Send(new CreateUserCommand(request.UserName));

        return Ok();
    }
}