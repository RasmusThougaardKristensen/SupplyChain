using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public interface IRegisterShipmentToWarehouseUseCase
{
    Task<WarehouseModel?> RegisterReceiptShipmentToWarehouse(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity);
}