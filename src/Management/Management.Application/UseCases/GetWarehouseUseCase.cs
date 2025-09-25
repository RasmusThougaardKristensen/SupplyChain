using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases;

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
}