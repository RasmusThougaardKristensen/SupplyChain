using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

public interface IGetWarehouseSummaryUseCase
{
    WarehouseSummaryDto? GetWarehouseStockSummary(WarehouseLocation location);
}