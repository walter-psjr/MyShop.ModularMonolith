using MediatR;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Application.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<Product>>;