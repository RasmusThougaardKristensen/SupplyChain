using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Shipments;

public interface IRegisterShipmentToCustomerUseCase
{
    WarehouseModel? RegisterDispatchShipmentToCustomer(WarehouseLocation targetWarehouseLocation, Sku sku, int quantity);
}