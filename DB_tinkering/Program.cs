using System.Reflection;
using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.OrderProposals.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderProposalContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/orderproposals", async (OrderProposalContext db) => await db.OrderProposals.ToListAsync());

app.MapPost("/orderproposals",
    async (OrderProposalContext db, OrderProposal order) =>
    {
        db.OrderProposals.Add(order);
        await db.SaveChangesAsync();

        return Results.Created($"/orderproposals/{order.OrderNumber}", order);
    });

app.MapControllers();

await app.RunAsync();