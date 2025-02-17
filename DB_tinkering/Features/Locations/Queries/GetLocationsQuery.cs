using DB_tinkering.Features.Locations.Models;
using MediatR;

namespace DB_tinkering.Features.Locations.Queries;

public class GetLocationsQuery : IRequest<List<Location>>
{
    public bool All { get; set; }
}