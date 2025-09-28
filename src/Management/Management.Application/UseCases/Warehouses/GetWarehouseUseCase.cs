using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses;

public class GetWarehouseUseCase : IGetWarehouseUseCase
{
    private readonly ICsvComponent _csvComponent;

    public GetWarehouseUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType)
    {
        return _csvComponent.GetWarehouses(sku, stateType);
    }

    public WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight)
    {
        return _csvComponent.GetWarehouseInventory(location, maxQuantity, minWeight, maxWeight);
    }
}