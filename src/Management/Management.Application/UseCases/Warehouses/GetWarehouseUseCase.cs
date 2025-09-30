using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses;

public class GetWarehouseUseCase : IGetWarehouseUseCase
{
    private readonly ICsvComponent _csvComponent;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ILegoSetRepository _legoSetRepository;

    public GetWarehouseUseCase(ICsvComponent csvComponent, IWarehouseRepository warehouseRepository, ILegoSetRepository legoSetRepository)
    {
        _csvComponent = csvComponent;
        _warehouseRepository = warehouseRepository;
        _legoSetRepository = legoSetRepository;
    }

    public IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType)
    {
        return _csvComponent.GetWarehouses(sku, stateType);
    }

    public IReadOnlyList<WarehouseModel> GetWarehousesWithAvailableStockForSkus(IReadOnlyList<Sku> requestedSkus)
    {
        var warehouses = _warehouseRepository.GetWarehousesWithSkus(requestedSkus);

        var warehousesWithAvailableStock = warehouses
            .Where(warehouse => warehouse.HasAvailableStock(requestedSkus))
            .ToList();

        return warehousesWithAvailableStock;
    }

    public WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight)
    {
        return _csvComponent.GetWarehouseInventory(location, maxQuantity, minWeight, maxWeight);
    }

    public WarehouseModel? GetWarehouseStockSummary(WarehouseLocation location)
    {
        return _csvComponent.GetWarehouseStockSummary(location);
    }
}