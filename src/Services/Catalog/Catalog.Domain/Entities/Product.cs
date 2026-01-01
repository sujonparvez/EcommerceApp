using BuildingBlocks.Core.Domain;

namespace Catalog.Domain.Entities;

public class Product : Entity<Guid>, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = default!;
    public string? ImageUrl { get; private set; }

    // Private constructor for EF Core
    private Product() { }

    public Product(string name, string description, decimal price, string category, string? imageUrl = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
    }

    public void Update(string name, string description, decimal price, string category, string? imageUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
    }
}
