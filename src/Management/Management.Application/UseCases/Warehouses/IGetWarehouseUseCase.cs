using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses;

public interface IGetWarehouseUseCase
{
    Task<IReadOnlyList<WarehouseModel>> GetWarehousesWithAvailableStockForSkus(IReadOnlyList<Sku> requestedSkus);
}