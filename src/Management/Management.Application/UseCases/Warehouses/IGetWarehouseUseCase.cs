using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses;

public interface IGetWarehouseUseCase
{
    IReadOnlyList<WarehouseModel> GetWarehousesWithAvailableStockForSkus(IReadOnlyList<Sku> requestedSkus);
    WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight);
    WarehouseModel? GetWarehouseStockSummary(WarehouseLocation location);
}