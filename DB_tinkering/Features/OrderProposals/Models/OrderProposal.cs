using System.ComponentModel.DataAnnotations.Schema;
using DB_tinkering.Features.Locations.Models;
using DB_tinkering.Features.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.Features.OrderProposals.Models;

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