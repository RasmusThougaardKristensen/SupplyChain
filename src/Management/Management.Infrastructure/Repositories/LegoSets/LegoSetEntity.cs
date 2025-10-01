namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public sealed class LegoSetEntity
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Theme { get; set; }
    public int Weight { get; set; }
    public string Rating { get; set; }
    public int PieceCount { get; set; }
    public string Uom { get; set; }
    public string ReleaseYear { get; set; }
    public string State { get; set; }
}