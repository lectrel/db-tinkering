using DB_tinkering.Features.Locations.Commands;
using DB_tinkering.Features.Locations.Models;
using DB_tinkering.Features.Locations.Queries;
using DB_tinkering.Features.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DB_tinkering.Features.Locations.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetLocations()
    {
        var query = new GetLocationsQuery { All = true };
        var locations = await mediator.Send(query);
        return Ok(locations);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateLocation(CreateLocationCommand command)
    {
        var location = await mediator.Send(command);
        return CreatedAtAction(nameof(GetLocations), new { id = location.Code }, location);
    }
}