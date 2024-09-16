using Microsoft.AspNetCore.Mvc;

namespace MyShop.ModularMonolith.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SharedController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Shared Controller!!!!!");
    }
}