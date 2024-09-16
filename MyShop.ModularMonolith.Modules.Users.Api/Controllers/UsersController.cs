using Microsoft.AspNetCore.Mvc;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Users.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = new List<User>
        {
            new(Guid.NewGuid(), "steve.jobs"),
            new(Guid.NewGuid(), "bill.gates")
        };

        return Ok(users);
    }
}