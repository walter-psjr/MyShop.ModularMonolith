using MediatR;

namespace MyShop.ModularMonolith.Modules.Products.Application.CreateProduct;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Unit>;