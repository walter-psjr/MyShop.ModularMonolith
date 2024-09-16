using MediatR;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Application.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), request.Name, request.Price);

        await _productRepository.AddAsync(product);
        
        return Unit.Value;
    }
}