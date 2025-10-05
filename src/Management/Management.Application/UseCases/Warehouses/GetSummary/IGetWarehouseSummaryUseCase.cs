using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

public interface IGetWarehouseSummaryUseCase
{
     Task<WarehouseSummaryDto?> GetWarehouseStockSummary(WarehouseLocation location);
}