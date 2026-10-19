
using AiShoppingAgent.Api.Data;

namespace AiShoppingAgent.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(
        this IEndpointRouteBuilder app)
    {

        app.MapGet("/api/products", (
            string? category,
            bool? available) =>
        {
            var products = MockProductCatalogue.Products.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                products = products.Where(product =>
                    product.Category.Equals(
                        category.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    ));
            }

            if (available.HasValue)
            {
                products = products.Where(product =>
                    product.Available == available.Value);
            }

            return Results.Ok(products.ToList());
        });

        app.MapGet("/api/products/search", (string? q) =>
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return Results.BadRequest(new
                {
                    message = "Please provide a search term using the q parameter."
                });
            }

            var searchTerm = q.Trim();

            var results = MockProductCatalogue.Products
                .Where(product =>
                    product.Name.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase
                    ) ||
                    product.Category.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase
                    ))
                .ToList();

            return Results.Ok(results);
        });

        return app;
    }
}
