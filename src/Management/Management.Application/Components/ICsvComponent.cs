using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    WarehouseModel? GetWarehouseStockSummary(WarehouseLocation location);
}