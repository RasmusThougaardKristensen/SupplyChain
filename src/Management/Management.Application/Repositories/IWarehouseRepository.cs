using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Repositories;

public interface IWarehouseRepository
{
    IReadOnlyList<WarehouseModel> GetWarehousesWithSkus(IReadOnlyList<Sku> requestedSkus);
    WarehouseModel? GetWarehouseByLocation(WarehouseLocation location);
}