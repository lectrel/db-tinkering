using Microsoft.EntityFrameworkCore;

namespace DB_tinkering.Features.Locations.Models;

[PrimaryKey(nameof(Code))]
public class Location
{
    public required string Code { get; set; }
    public string Name { get; set; }
}