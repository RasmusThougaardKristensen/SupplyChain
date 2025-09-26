using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Api.Endpoints.LegoSets;

public sealed record LegoSetResponse
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

    public LegoSetResponse(LegoSetModel legoSet)
    {
        Sku = legoSet.Sku.Id;
        Name = legoSet.Name;
        Theme = legoSet.Theme;
        Weight = legoSet.Weight;
        Rating = legoSet.Rating;
        Pieces = legoSet.Pieces;
        Uom = legoSet.Uom.Id;
        ReleaseYear = legoSet.ReleaseYear;
        State = legoSet.State.ToString();
    }
}