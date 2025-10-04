using SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.Services.Warehouses;

public class WarehouseSummaryService : IWarehouseSummaryService
{
    public WarehouseSummaryDto GetWarehouseStockSummary(WarehouseLocation location, IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets)
    {
        var categoryStocks = legoSets
            .Join(stocks,
            legoSet => legoSet.Sku,
            stock => stock.Sku,
            ToModel)
            .ToList();

        return new WarehouseSummaryDto(location,categoryStocks);
    }

    private CategoryStockDto ToModel(LegoSetModel legoSet, Stock stock)
    {
        return new CategoryStockDto(legoSet.Sku, legoSet.Name, legoSet.Theme, stock.Quantity);
    }
}