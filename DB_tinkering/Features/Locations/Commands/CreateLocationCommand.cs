using DB_tinkering.Features.Locations.Models;
using MediatR;

namespace DB_tinkering.Features.Locations.Commands;

public abstract class CreateLocationCommand : IRequest<Location>
{
    public string Code { get; set; }
    public string Name { get; set; }
}