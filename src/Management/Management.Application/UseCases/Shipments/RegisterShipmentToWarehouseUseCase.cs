using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public class RegisterShipmentToWarehouseUseCase : IRegisterShipmentToWarehouseUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public RegisterShipmentToWarehouseUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public WarehouseModel? RegisterReceiptShipmentToWarehouse(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity)
    {
        var targetWarehouse = _warehouseRepository.GetWarehouseByLocation(targetWarehouseLocation);
        if (targetWarehouse is null)
        {
            return null;
        }

        targetWarehouse.Inventory.IncreaseStockLevel(new Stock(sku, quantity));

        return targetWarehouse;
    }
}