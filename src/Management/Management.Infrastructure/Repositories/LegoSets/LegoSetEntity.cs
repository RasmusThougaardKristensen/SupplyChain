using SupplyChain.Management.Infrastructure.Repositories.Warehouses;

namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public sealed class LegoSetEntity
{
    public required string SKU { get; set; }
    public required string Name { get; set; }
    public required string Theme { get; set; }
    public required int Weight { get; set; }
    public required string Rating { get; set; }
    public required int PieceCount { get; set; }
    public required string Uom { get; set; }
    public required string ReleaseYear { get; set; }
    public required string State { get; set; }
    public required ICollection<StockEntity> Stocks { get; set; }
}