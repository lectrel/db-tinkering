using DB_tinkering.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.DB.Contexts;

public class OrderProposalContext(IConfiguration configuration) : DbContext
{
    public DbSet<OrderProposal> OrderProposals { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"])
            .UseSnakeCaseNamingConvention();
}