using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Domain.Warehouses;

public class WarehouseModel
{
    public WarehouseId WarehouseId { get; }
    public WarehouseLocation Location { get; }
    public Inventory Inventory { get; }

    public WarehouseModel(WarehouseLocation location, Inventory inventory)
        : this(
            warehouseId:new WarehouseId(),
            location: location,
            inventory: inventory) { }

    public WarehouseModel(WarehouseId warehouseId, WarehouseLocation location, Inventory inventory)
    {
        WarehouseId = warehouseId;
        Location = location;
        Inventory = inventory;
    }

    public bool HasAvailableStock(IReadOnlyList<Sku> requestedSkus)
    {
        return GetAvailableStocksForSkus(requestedSkus).Any();
    }

    private IReadOnlyList<Stock> GetAvailableStocksForSkus(IReadOnlyList<Sku> requestedSkus)
    {
        return Inventory.GetStocksWithSkus(requestedSkus)
            .Where(stock => stock.IsAvailable)
            .ToList();
    }
}