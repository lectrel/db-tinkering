using DB_tinkering.Features.Products.Models;
using MediatR;

namespace DB_tinkering.Features.Products.Queries;

public class GetProductsQuery : IRequest<List<Product>>
{
    public bool WithSuppliers { get; set; }
    public bool WithGroups { get; set; }
}