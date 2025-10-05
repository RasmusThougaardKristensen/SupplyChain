using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Repositories;

public interface IWarehouseRepository
{
    Task<IReadOnlyList<WarehouseModel>> GetWarehousesWithSkus(IReadOnlyList<Sku> requestedSkus);
    Task<WarehouseModel?> GetWarehouseByLocation(WarehouseLocation location);
}