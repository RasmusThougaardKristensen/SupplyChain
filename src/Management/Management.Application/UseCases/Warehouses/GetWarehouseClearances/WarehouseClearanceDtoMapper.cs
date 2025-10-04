using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public class WarehouseClearanceDtoMapper : IWarehouseClearanceDtoMapper
{
    public WarehouseClearanceDto ToClearanceItems(IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets)
    {
        var legoSetsBySku = legoSets.ToDictionary(legoSet => legoSet.Sku);

        var clearanceLegoSetModels= stocks
            .Where(stock => legoSetsBySku.ContainsKey(stock.Sku))
            .Select(stock => ToModel(legoSetsBySku[stock.Sku], stock))
            .ToList();

        var clearanceItemModel = new WarehouseClearanceDto(clearanceLegoSetModels);
        return clearanceItemModel;
    }

    private WarehouseClearanceLegoSetDto ToModel(LegoSetModel legoSet, Stock stock)
    {
        return new WarehouseClearanceLegoSetDto(legoSet.Sku, legoSet.Name, stock.Quantity, legoSet.Weight, stock.Placement);
    }
}