using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public class RegisterShipmentToCustomerUseCase : IRegisterShipmentToCustomerUseCase
{
    private readonly ICsvComponent _csvComponent;

    public RegisterShipmentToCustomerUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public WarehouseModel? RegisterDispatchShipmentToCustomer(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity)
    {
        var targetWarehouse = _csvComponent.GetWarehouseByLocation(targetWarehouseLocation);
        if (targetWarehouse is null)
        {
            return null;
        }

        targetWarehouse.Inventory.DecreaseStockLevel(new Stock(sku, quantity));

        return targetWarehouse;
    }
}