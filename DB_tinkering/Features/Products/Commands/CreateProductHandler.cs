using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.Products.Models;
using MediatR;

namespace DB_tinkering.Features.Products.Commands;

public class CreateProductHandler(OrderProposalContext context) : IRequestHandler<CreateProductCommand, Product>
{

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            PurchasePrice = request.PurchasePrice,
            SalesPrice = request.SalePrice,
            ProductGroupCode = request.ProductGroupCode,
            SupplierCode = request.SupplierCode,
            Category = request.Category
        };

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }
}