namespace SupplyChain.Management.Infrastructure.Datasets;

public sealed class SetEntity
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Theme { get; set; }
    public int Weight { get; set; }
    public string Rating { get; set; }
    public int PieceCount { get; set; }
    public string Uom { get; set; }
    public int ReleaseYear { get; set; }
    public string State { get; set; }
}