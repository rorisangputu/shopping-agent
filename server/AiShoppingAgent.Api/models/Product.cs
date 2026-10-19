
namespace AiShoppingAgent.Api.Models;

public class Product
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Category { get; init; }

    public decimal Price { get; init; }

    public required string Size { get; init; }

    public bool Available { get; init; }
}
