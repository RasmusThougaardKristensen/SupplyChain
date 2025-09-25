using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    SetModel? GetSetBySku(Sku sku);
    IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType);
}