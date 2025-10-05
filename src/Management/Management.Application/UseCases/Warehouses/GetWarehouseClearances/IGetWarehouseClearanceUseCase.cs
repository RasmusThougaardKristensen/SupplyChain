using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public interface IGetWarehouseClearanceUseCase
{
    IReadOnlyList<WarehouseClearanceLegoSetDto> GetWarehouseClearance(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight);
}