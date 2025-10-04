using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses;

public class GetWarehouseUseCase : IGetWarehouseUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public GetWarehouseUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public IReadOnlyList<WarehouseModel> GetWarehousesWithAvailableStockForSkus(IReadOnlyList<Sku> requestedSkus)
    {
        var warehouses = _warehouseRepository.GetWarehousesWithSkus(requestedSkus);

        var warehousesWithAvailableStock = warehouses
            .Where(warehouse => warehouse.HasAvailableStock(requestedSkus))
            .ToList();

        return warehousesWithAvailableStock;
    }
}