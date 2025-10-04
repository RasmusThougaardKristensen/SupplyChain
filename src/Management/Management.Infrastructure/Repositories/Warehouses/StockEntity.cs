using SupplyChain.Management.Infrastructure.Repositories.LegoSets;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public sealed class StockEntity
{
    public required Guid Id { get; set; }
    public required string Warehouse { get; set; }
    public required string SKU { get; set; }
    public required int Quantity { get; set; }
    public required string DeliveryDate { get; set; }
    public required string Uom { get; set; }
    public required int Placement { get; set; }
    public required int Shelf { get; set; }
    public LegoSetEntity LegoSet { get; set; }
}