using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases;

public interface IGetWarehouseUseCase
{
    IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType);
    WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight);
}