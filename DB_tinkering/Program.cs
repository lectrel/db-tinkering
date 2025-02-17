using DB_tinkering.DB.Contexts;
using DB_tinkering.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderProposalContext>();

var app = builder.Build();

app.MapGet("/locations", async (OrderProposalContext db) => await db.Locations.ToListAsync());

app.MapGet("/products",
    async (OrderProposalContext db,
        [FromQuery(Name = "withSuppliers")] bool withSuppliers = false,
        [FromQuery(Name = "withGroups")] bool withGroups = false
    ) =>
    {
        IQueryable<Product> products = db.Products;
        if (withSuppliers) products = products.Include(product => product.Supplier);
        if (withGroups) products = products.Include(p => p.ProductGroup);
        return await products.ToListAsync();
    });

app.MapGet("/orderproposals", async (OrderProposalContext db) => await db.OrderProposals.ToListAsync());

app.MapPost("/locations",
    async (OrderProposalContext db, Location location) =>
    {
        db.Locations.Add(location);
        await db.SaveChangesAsync();

        return Results.Created($"/locations/{location.Code}", location);
    });

app.MapPost("/products",
    async (OrderProposalContext db, Product product) =>
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();

        return Results.Created($"/locations/{product.Code}", product);
    });

app.MapPost("/orderproposals",
    async (OrderProposalContext db, OrderProposal order) =>
    {
        db.OrderProposals.Add(order);
        await db.SaveChangesAsync();

        return Results.Created($"/locations/{order.OrderNumber}", order);
    });

await app.RunAsync();