using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Domain.ClearanceSale;

public sealed record WarehouseClearanceLegoSet
{
    public Sku Sku { get; }
    public string Name { get; }
    public int Quantity { get; }
    public int Weight { get; }
    public StockPlacement Placement { get; }
    public WarehouseClearanceLegoSet(Sku sku, string name, int quantity, int weight, StockPlacement placement)
    {
        Sku = sku;
        Name = name;
        Quantity = quantity;
        Weight = weight;
        Placement = placement;
    }
}