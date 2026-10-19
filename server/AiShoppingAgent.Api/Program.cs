
using AiShoppingAgent.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ExtensionDev", policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
                origin.StartsWith(
                    "chrome-extension://",
                    StringComparison.OrdinalIgnoreCase
                ) ||
                origin.StartsWith(
                    "http://localhost:",
                    StringComparison.OrdinalIgnoreCase
                ) ||
                origin.StartsWith(
                    "http://127.0.0.1:",
                    StringComparison.OrdinalIgnoreCase
                ))
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ExtensionDev");

app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        service = "AI Shopping Agent API"
    });
});
app.MapProductEndpoints();
app.Run();
