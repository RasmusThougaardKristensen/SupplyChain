using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;

namespace SupplyChain.Management.Api.Endpoints;

public sealed record SetResponse
{
    public string Sku { get; }
    public string Name { get; }
    public string Theme { get; }
    public int Weight { get; }
    public string Rating { get; }
    public int Pieces { get; }
    public string Uom { get; }
    public string ReleaseYear { get; }
    public string State { get; }

    public SetResponse(SetModel set)
    {
        Sku = set.Sku.Id;
        Name = set.Name;
        Theme = set.Theme;
        Weight = set.Weight;
        Rating = set.Rating;
        Pieces = set.Pieces;
        Uom = set.Uom.Id;
        ReleaseYear = set.ReleaseYear;
        State = set.State;
    }
}