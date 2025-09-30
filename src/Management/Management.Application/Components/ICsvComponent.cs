using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minweight, int maxWeight);
    WarehouseModel? GetWarehouseStockSummary(WarehouseLocation location);
}