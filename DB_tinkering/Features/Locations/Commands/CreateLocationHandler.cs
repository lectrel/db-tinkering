using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.Locations.Models;
using MediatR;

namespace DB_tinkering.Features.Locations.Commands;

public class CreateLocationHandler(OrderProposalContext context) : IRequestHandler<CreateLocationCommand, Location>
{

    public async Task<Location> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Location { Code = request.Code, Name = request.Name };

        context.Locations.Add(location);
        await context.SaveChangesAsync(cancellationToken);

        return location;
    }
}