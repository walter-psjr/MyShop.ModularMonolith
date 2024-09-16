using Microsoft.AspNetCore.Mvc;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = new List<Product>
        {
            new(Guid.NewGuid(), "MacBook", 2399),
            new(Guid.NewGuid(), "iPhone", 700)
        };

        return Ok(products);
    }
}