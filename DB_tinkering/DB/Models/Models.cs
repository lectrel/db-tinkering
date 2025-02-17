using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.DB.Models;

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