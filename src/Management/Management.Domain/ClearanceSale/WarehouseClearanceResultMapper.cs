using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Domain.ClearanceSale;

public class WarehouseClearanceResultMapper : IWarehouseClearanceResultMapper
{
    public WarehouseClearanceResult ToClearanceItems(IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets)
    {
        var legoSetsBySku = legoSets.ToDictionary(legoSet => legoSet.Sku);

        var clearanceLegoSetModels= stocks
            .Where(stock => legoSetsBySku.ContainsKey(stock.Sku))
            .Select(stock => ToModel(legoSetsBySku[stock.Sku], stock))
            .ToList();

        var clearanceItemModel = new WarehouseClearanceResult(clearanceLegoSetModels);
        return clearanceItemModel;
    }

    private WarehouseClearanceLegoSet ToModel(LegoSetModel legoSet, Stock stock)
    {
        return new WarehouseClearanceLegoSet(legoSet.Sku, legoSet.Name, stock.Quantity, legoSet.Weight, stock.Placement);
    }
}