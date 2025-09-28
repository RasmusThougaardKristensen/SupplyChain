using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    LegoSetModel? GetSetBySku(Sku sku);
    IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType);
    WarehouseModel? GetWarehouseByLocation(WarehouseLocation location);
    WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minweight, int maxWeight);
}