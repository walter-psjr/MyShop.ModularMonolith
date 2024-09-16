using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyShop.ModularMonolith.Modules.Products.Application.CreateProduct;
using MyShop.ModularMonolith.Modules.Products.Application.GetAllProducts;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        await _mediator.Send(new CreateProductCommand(request.Name, request.Price));

        return Ok();
    }
}