using DB_tinkering.DB.Contexts;
using DB_tinkering.Features.Locations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.Features.Locations.Queries;

public class GetLocationsHandler(OrderProposalContext context) : IRequestHandler<GetLocationsQuery, List<Location>>
{

    public async Task<List<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        return await context.Locations.ToListAsync(cancellationToken);
    }
}