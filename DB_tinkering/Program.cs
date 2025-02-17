using System.Reflection;
using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.Locations.Models;
using DB_tinkering.Features.OrderProposals.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderProposalContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.MapGet("/locations", async (OrderProposalContext db) => await db.Locations.ToListAsync());

app.MapGet("/orderproposals", async (OrderProposalContext db) => await db.OrderProposals.ToListAsync());

app.MapPost("/locations",
    async (OrderProposalContext db, Location location) =>
    {
        db.Locations.Add(location);
        await db.SaveChangesAsync();

        return Results.Created($"/locations/{location.Code}", location);
    });

app.MapPost("/orderproposals",
    async (OrderProposalContext db, OrderProposal order) =>
    {
        db.OrderProposals.Add(order);
        await db.SaveChangesAsync();

        return Results.Created($"/locations/{order.OrderNumber}", order);
    });

app.MapControllers();

await app.RunAsync();