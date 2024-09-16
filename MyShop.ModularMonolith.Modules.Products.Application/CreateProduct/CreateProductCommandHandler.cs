using MassTransit;
using MediatR;
using MyShop.ModularMonolith.Modules.Products.Domain.Products;

namespace MyShop.ModularMonolith.Modules.Products.Application.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IBus _bus;

    public CreateProductCommandHandler(IProductRepository productRepository, IBus bus)
    {
        _productRepository = productRepository;
        _bus = bus;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), request.Name, request.Price);

        await _productRepository.AddAsync(product);

        await _bus.Publish(new ProductCreatedDomainEvent(Guid.NewGuid(), product.Id));
        
        return Unit.Value;
    }
}