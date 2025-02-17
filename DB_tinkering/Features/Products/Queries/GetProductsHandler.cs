using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.Features.Products.Queries;

public class GetProductsHandler(OrderProposalContext context) : IRequestHandler<GetProductsQuery, List<Product>>
{

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Product> products = context.Products;
        if (request.WithSuppliers) products = products.Include(p => p.Supplier);
        if (request.WithGroups) products = products.Include(p => p.ProductGroup);
        return await products.ToListAsync(cancellationToken);
    }
}