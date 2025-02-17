using DB_tinkering.Features.Products.Commands;
using DB_tinkering.Features.Products.Models;
using DB_tinkering.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DB_tinkering.Features.Products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] bool withSuppliers = false,
        [FromQuery] bool withGroups = false)
    {
        var query = new GetProductsQuery { WithSuppliers = withSuppliers, WithGroups = withGroups };
        var products = await mediator.Send(query);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(CreateProductCommand command)
    {
        var product = await mediator.Send(command);
        return CreatedAtAction(nameof(GetProducts), new { id = product.Code }, product);
    }
}