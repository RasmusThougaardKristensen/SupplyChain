using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public sealed record WarehouseClearanceLegoSetDto
{
    public Sku Sku { get; }
    public string Name { get; }
    public int Quantity { get; }
    public int Weight { get; }
    public StockPlacement Placement { get; }
    public WarehouseClearanceLegoSetDto(Sku sku, string name, int quantity, int weight, StockPlacement placement)
    {
        Sku = sku;
        Name = name;
        Quantity = quantity;
        Weight = weight;
        Placement = placement;
    }
}