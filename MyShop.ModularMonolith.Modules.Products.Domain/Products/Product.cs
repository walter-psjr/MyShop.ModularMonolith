namespace MyShop.ModularMonolith.Modules.Products.Domain.Products;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; set; }
}