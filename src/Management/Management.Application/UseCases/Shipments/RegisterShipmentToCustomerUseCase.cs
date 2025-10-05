using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public class RegisterShipmentToCustomerUseCase : IRegisterShipmentToCustomerUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public RegisterShipmentToCustomerUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<WarehouseModel?> RegisterDispatchShipmentToCustomer(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity)
    {
        var targetWarehouse = await _warehouseRepository.GetWarehouseByLocation(targetWarehouseLocation);
        if (targetWarehouse is null)
        {
            return null;
        }

        targetWarehouse.Inventory.DecreaseStockLevel(new Stock(sku, quantity));

        return targetWarehouse;
    }
}