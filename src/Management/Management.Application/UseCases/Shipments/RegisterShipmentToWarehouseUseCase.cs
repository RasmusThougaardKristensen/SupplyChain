using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public class RegisterShipmentToWarehouseUseCase : IRegisterShipmentToWarehouseUseCase
{
    private readonly ICsvComponent _csvComponent;

    public RegisterShipmentToWarehouseUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public WarehouseModel? RegisterIncomingShipmentToWarehouse(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity)
    {
        var targetWarehouse = _csvComponent.GetWarehouseByLocation(targetWarehouseLocation);
        if (targetWarehouse is null)
        {
            return null;
        }

        targetWarehouse.Inventory.IncreaseStockLevel(new Stock(sku, quantity));

        return targetWarehouse;
    }
}