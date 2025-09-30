using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;
using SupplyChain.Management.Infrastructure.Repositories.LegoSets;
using SupplyChain.Management.Infrastructure.Repositories.Warehouses;

namespace SupplyChain.Management.Infrastructure.Datasets;

public sealed class CsvComponent : ICsvComponent
{
    private const string setsPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Repositories/Legosets/sets.csv";
    private const string stocksPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Repositories/Warehouses/stock.csv";

    public WarehouseModel? GetWarehouseInventory(WarehouseLocation location, int maxQuantity, int minweight, int maxWeight)
    {
        var legoSetEntities = ReadSetsFromCsv();
        var stockEntities = ReadStocksFromCsv();

        var houseware = stockEntities.FirstOrDefault(stockEntity => stockEntity.Warehouse == location.Id);

        if (houseware is null)
        {
            return null;
        }

        var filteredStocks = stockEntities
            .Where(stock => stock.Warehouse == location.Id && stock.Quantity <= maxQuantity)
            .Where(stock => legoSetEntities.Any(legoSet =>
                legoSet.SKU == stock.SKU &&
                legoSet.Weight >= minweight && legoSet.Weight <= maxWeight));

        return ToModel(filteredStocks, location);
    }

    public WarehouseModel? GetWarehouseStockSummary(WarehouseLocation location)
    {
        var legoSetEntities = ReadSetsFromCsv();
        var stockEntities = ReadStocksFromCsv();

        var houseware = stockEntities.FirstOrDefault(stockEntity => stockEntity.Warehouse == location.Id);

        if (houseware is null)
        {
            return null;
        }

        var stocksTheme = stockEntities.Where(stock =>
            stock.Warehouse == location.Id &&
            legoSetEntities.Any(legoSet => legoSet.SKU == stock.SKU));

        return ToModel(stocksTheme, location);
    }

    private WarehouseModel ToModel(IEnumerable<StockEntity> stockEntities, WarehouseLocation warehouseLocation)
    {
        var stocks = new List<Stock>();
        foreach (var stockEntity in stockEntities)
        {
            var stock = new Stock(
                new Sku(stockEntity.SKU),
                stockEntity.Quantity,
                ParseDeliveryDate(stockEntity.DeliveryDate),
                new Uom(stockEntity.Uom),
                new StockPlacement(stockEntity.Placement, stockEntity.Shelf));

            stocks.Add(stock);
        }

        var inventory = new Inventory(stocks);
        var warehouse = new WarehouseModel(
            location: warehouseLocation,
            inventory: inventory);

        return warehouse;
    }

    private static IReadOnlyList<LegoSetEntity> ReadSetsFromCsv()
    {
        using var reader = new StringReader(File.ReadAllText(setsPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<LegoSetCsvMap>();
        var setEntities = csv.GetRecords<LegoSetEntity>();

        return setEntities.ToList();
    }

    private static IReadOnlyList<StockEntity> ReadStocksFromCsv()
    {
        using var reader = new StringReader(File.ReadAllText(stocksPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<StockCsvMap>();
        var stockEntities = csv.GetRecords<StockEntity>();

        return stockEntities.ToList();
    }

    private DateTime ParseDeliveryDate(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return result;
        }

        string[] formats = { "yyyy-MM-dd" };
        foreach (var format in formats)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
        }

        throw new FormatException($"Unable to parse date: {dateString}");
    }
}