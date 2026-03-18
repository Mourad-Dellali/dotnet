using APIVersioning.Model;

namespace APIVersioning.Data;


public class ProductRepository
{
    private readonly List<Product> _products = [
        new Product
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Laptop",
            Price = 1299.99m
        },
        new Product
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Mechanical Keyboard",
            Price = 149.50m
        },
        new Product
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Wireless Mouse",
            Price = 79.00m
        },
        new Product
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "27-inch Monitor",
            Price = 349.99m
        },
        new Product
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "USB-C Hub",
            Price = 49.99m
        }
    ];
    public Product? GetProductById(Guid productId) {
        var product = _products.FirstOrDefault(p=>p.Id == productId);

        return product ?? null;
    }
}