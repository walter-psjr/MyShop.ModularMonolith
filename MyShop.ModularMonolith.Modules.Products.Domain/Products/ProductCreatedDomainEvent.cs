namespace MyShop.ModularMonolith.Modules.Products.Domain.Products;

public class ProductCreatedDomainEvent
{
    public ProductCreatedDomainEvent(Guid eventId, Guid productId)
    {
        EventId = eventId;
        ProductId = productId;
    }

    public Guid EventId { get; }
    public Guid ProductId { get; }
}