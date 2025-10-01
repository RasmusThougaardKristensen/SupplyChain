using SupplyChain.Management.Domain.ClearanceSale;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.ClearanceSale;

public interface IGetWarehouseClearanceUseCase
{
    IReadOnlyList<WarehouseClearanceLegoSet> GetWarehouseClearance(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight);
}