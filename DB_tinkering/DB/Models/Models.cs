using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.DB.Models;

[PrimaryKey(nameof(OrderNumber))]
public class OrderProposal
{
    public required string OrderNumber { get; set; }
    [ForeignKey("ProductCode")] public Product Product { get; set; }
    public string ProductCode { get; set; }
    [ForeignKey("LocationCode")] public Location Location { get; set; }
    public string LocationCode { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public float ProposedQuantity { get; set; }
    public float CorrectedQuantity { get; set; }
    public int Status { get; set; }
    public float BatchSize { get; set; }
    public string Type { get; set; }
    public TimeOnly EditableFrom { get; set; }
    public TimeOnly EditableTo { get; set; }
}

[PrimaryKey(nameof(Code))]
public class Location
{
    public required string Code { get; set; }
    public string Name { get; set; }
}

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

[PrimaryKey(nameof(Code))]
public class ProductGroup
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

[PrimaryKey(nameof(Code))]
public class Supplier
{
    public string Code { get; set; }
    public string Name { get; set; }
    public float MinOrderQuantity { get; set; }
    public float MaxOrderQuantity { get; set; }
}