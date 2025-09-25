using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Domain.Sets;

public sealed class SetModel
{
    public Sku Sku { get; }
    public string Name { get; }
    public string Theme { get; }
    public int Weight { get; }
    public string Rating { get; }
    public int Pieces { get; }
    public Uom Uom { get; }
    public string ReleaseYear { get; }
    public StateType State { get; }

    public SetModel(Sku sku, string name, string theme, int weight, string rating, int pieces, Uom uom, string releaseYear, StateType state)
    {
        Sku = sku;
        Name = name;
        Theme = theme;
        Weight = weight;
        Rating = rating;
        Pieces = pieces;
        Uom = uom;
        ReleaseYear = releaseYear;
        State = state;
    }
}