using System.ComponentModel.DataAnnotations.Schema;
using DB_tinkering.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.Features.Products.Models;

[PrimaryKey(nameof(Code))]
public class Product
{
    public required string Code { get; set; }
    public string Name { get; set; }
    public float PurchasePrice { get; set; }
    public float SalesPrice { get; set; }
    [ForeignKey("SupplierCode")] public Supplier Supplier { get; set; }
    public string SupplierCode { get; set; }
    public string Category { get; set; }
    [ForeignKey("ProductGroupCode")] public ProductGroup ProductGroup { get; set; }
    public string ProductGroupCode { get; set; }
    public string Description { get; set; }
}