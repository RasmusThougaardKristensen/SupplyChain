using SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.Services.Warehouses;

public interface IWarehouseSummaryService
{
    public WarehouseSummaryDto GetWarehouseStockSummary(WarehouseLocation location,IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets);
}