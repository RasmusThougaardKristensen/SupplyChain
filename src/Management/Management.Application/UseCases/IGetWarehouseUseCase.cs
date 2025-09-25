using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases;

public interface IGetWarehouseUseCase
{
    IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType);
}