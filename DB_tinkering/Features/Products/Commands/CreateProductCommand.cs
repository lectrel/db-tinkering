using DB_tinkering.Features.Products.Models;
using MediatR;

namespace DB_tinkering.Features.Products.Commands;

public abstract class CreateProductCommand : IRequest<Product>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float PurchasePrice { get; set; }
    public float SalePrice { get; set; }
    public string ProductGroupCode { get; set; }
    public string SupplierCode { get; set; }
    public string Category { get; set; }
}