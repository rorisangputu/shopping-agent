
using AiShoppingAgent.Api.Models;

namespace AiShoppingAgent.Api.Data;

public static class MockProductCatalogue
{
    public static readonly List<Product> Products =
    [
        new() { Id = "prod-001", Name = "Beef Steak 1kg", Category = "Meat", Price = 149.99m, Size = "1kg", Available = true },
        new() { Id = "prod-002", Name = "Boerewors 1kg", Category = "Meat", Price = 129.99m, Size = "1kg", Available = true },
        new() { Id = "prod-003", Name = "Chicken Thighs 2kg", Category = "Meat", Price = 119.99m, Size = "2kg", Available = true },
        new() { Id = "prod-004", Name = "Beef Mince 1kg", Category = "Meat", Price = 99.99m, Size = "1kg", Available = true },
        new() { Id = "prod-005", Name = "Pork Ribs 1kg", Category = "Meat", Price = 139.99m, Size = "1kg", Available = true },
        new() { Id = "prod-006", Name = "Chicken Wings 1kg", Category = "Meat", Price = 89.99m, Size = "1kg", Available = true },
        new() { Id = "prod-007", Name = "Lamb Chops 1kg", Category = "Meat", Price = 189.99m, Size = "1kg", Available = true },
        new() { Id = "prod-008", Name = "Whole Chicken", Category = "Meat", Price = 79.99m, Size = "1.5kg", Available = true },

        new() { Id = "prod-009", Name = "Hamburger Rolls", Category = "Bakery", Price = 39.99m, Size = "6 pack", Available = true },
        new() { Id = "prod-010", Name = "Hot Dog Rolls", Category = "Bakery", Price = 34.99m, Size = "6 pack", Available = true },
        new() { Id = "prod-011", Name = "White Bread", Category = "Bakery", Price = 17.99m, Size = "700g", Available = true },
        new() { Id = "prod-012", Name = "Brown Bread", Category = "Bakery", Price = 18.99m, Size = "700g", Available = true },
        new() { Id = "prod-013", Name = "Burger Buns", Category = "Bakery", Price = 44.99m, Size = "8 pack", Available = true },
        new() { Id = "prod-014", Name = "Pita Bread", Category = "Bakery", Price = 29.99m, Size = "6 pack", Available = true },

        new() { Id = "prod-015", Name = "Cola Soft Drink", Category = "Drinks", Price = 39.99m, Size = "2L", Available = true },
        new() { Id = "prod-016", Name = "Lemon-Lime Soft Drink", Category = "Drinks", Price = 34.99m, Size = "2L", Available = true },
        new() { Id = "prod-017", Name = "Bottled Water", Category = "Drinks", Price = 49.99m, Size = "6 x 1.5L", Available = true },
        new() { Id = "prod-018", Name = "Orange Juice", Category = "Drinks", Price = 29.99m, Size = "1L", Available = true },
        new() { Id = "prod-019", Name = "Energy Drink", Category = "Drinks", Price = 44.99m, Size = "6 x 500ml", Available = true },
        new() { Id = "prod-020", Name = "Sparkling Water", Category = "Drinks", Price = 24.99m, Size = "1L", Available = true },

        new() { Id = "prod-021", Name = "Potato Chips", Category = "Snacks", Price = 24.99m, Size = "150g", Available = true },
        new() { Id = "prod-022", Name = "Mixed Nuts", Category = "Snacks", Price = 49.99m, Size = "300g", Available = true },
        new() { Id = "prod-023", Name = "Salted Peanuts", Category = "Snacks", Price = 19.99m, Size = "250g", Available = true },
        new() { Id = "prod-024", Name = "Popcorn", Category = "Snacks", Price = 14.99m, Size = "100g", Available = true },
        new() { Id = "prod-025", Name = "Chocolate Biscuits", Category = "Snacks", Price = 22.99m, Size = "200g", Available = true },
        new() { Id = "prod-026", Name = "Pretzels", Category = "Snacks", Price = 27.99m, Size = "200g", Available = true },

        new() { Id = "prod-027", Name = "Potatoes", Category = "Produce", Price = 34.99m, Size = "2kg", Available = true },
        new() { Id = "prod-028", Name = "Onions", Category = "Produce", Price = 19.99m, Size = "1kg", Available = true },
        new() { Id = "prod-029", Name = "Carrots", Category = "Produce", Price = 16.99m, Size = "1kg", Available = true },
        new() { Id = "prod-030", Name = "Tomatoes", Category = "Produce", Price = 24.99m, Size = "1kg", Available = true },
        new() { Id = "prod-031", Name = "Lettuce", Category = "Produce", Price = 14.99m, Size = "1 head", Available = true },
        new() { Id = "prod-032", Name = "Avocados", Category = "Produce", Price = 39.99m, Size = "4 pack", Available = true },
        new() { Id = "prod-033", Name = "Bananas", Category = "Produce", Price = 22.99m, Size = "1kg", Available = true },
        new() { Id = "prod-034", Name = "Apples", Category = "Produce", Price = 29.99m, Size = "1kg", Available = true },

        new() { Id = "prod-035", Name = "Cheddar Cheese", Category = "Dairy", Price = 69.99m, Size = "400g", Available = true },
        new() { Id = "prod-036", Name = "Milk", Category = "Dairy", Price = 19.99m, Size = "1L", Available = true },
        new() { Id = "prod-037", Name = "Butter", Category = "Dairy", Price = 39.99m, Size = "250g", Available = true },
        new() { Id = "prod-038", Name = "Plain Yoghurt", Category = "Dairy", Price = 32.99m, Size = "1kg", Available = true },
        new() { Id = "prod-039", Name = "Fresh Cream", Category = "Dairy", Price = 29.99m, Size = "250ml", Available = true },

        new() { Id = "prod-040", Name = "Tomato Sauce", Category = "Condiments", Price = 24.99m, Size = "700ml", Available = true },
        new() { Id = "prod-041", Name = "Mayonnaise", Category = "Condiments", Price = 34.99m, Size = "750g", Available = true },
        new() { Id = "prod-042", Name = "Mustard", Category = "Condiments", Price = 19.99m, Size = "250g", Available = true },
        new() { Id = "prod-043", Name = "BBQ Sauce", Category = "Condiments", Price = 29.99m, Size = "500ml", Available = true },
        new() { Id = "prod-044", Name = "Cooking Oil", Category = "Pantry", Price = 54.99m, Size = "2L", Available = true },
        new() { Id = "prod-045", Name = "Rice", Category = "Pantry", Price = 39.99m, Size = "2kg", Available = true },
        new() { Id = "prod-046", Name = "Pasta", Category = "Pantry", Price = 17.99m, Size = "500g", Available = true },
        new() { Id = "prod-047", Name = "Baked Beans", Category = "Pantry", Price = 16.99m, Size = "410g", Available = true },
        new() { Id = "prod-048", Name = "Breakfast Cereal", Category = "Pantry", Price = 49.99m, Size = "750g", Available = true },
        new() { Id = "prod-049", Name = "Dishwashing Liquid", Category = "Household", Price = 29.99m, Size = "750ml", Available = true },
        new() { Id = "prod-050", Name = "Kitchen Paper Towels", Category = "Household", Price = 39.99m, Size = "2 rolls", Available = true }
    ];
}
