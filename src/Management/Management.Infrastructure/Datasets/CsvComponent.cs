using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Infrastructure.Datasets;

public sealed class CsvComponent : ICsvComponent
{
    private const string setsPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Datasets/sets.csv";
    private const string stocksPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Datasets/stock.csv";
    public LegoSetModel? GetSetBySku(Sku sku)
    {
        var setEntities = ReadSetsFromCsv();

        var entity = setEntities.FirstOrDefault(setEntity => setEntity.SKU == sku.Id);

        return entity is null ? null : ToModel(entity);
    }

    public IReadOnlyList<WarehouseModel> GetWarehouses(Sku sku, StateType stateType)
    {
        var legoSetEntities = ReadSetsFromCsv();
        var stockEntities = ReadStocksFromCsv();

        var availableSets = legoSetEntities.Where(set => set.State == stateType.ToString());

        var warehouses = stockEntities.Where(stockEntity => availableSets.Any(availableSetEntity => availableSetEntity.SKU == stockEntity.SKU));

        return GroupWarehouses(warehouses);
    }

    public WarehouseModel? GetWarehouseByLocation(WarehouseLocation location)
    {
        var stockEntities = ReadStocksFromCsv();
        var warehouse = stockEntities.FirstOrDefault(stock => stock.Warehouse == location.Id);

        if (warehouse is null)
        {
            return null;
        }

        var stocks = stockEntities.Where(x => x.Warehouse == warehouse.Warehouse);

        return ToModel(stocks, new WarehouseLocation(warehouse.Warehouse));
    }

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

    private IReadOnlyList<WarehouseModel> GroupWarehouses(IEnumerable<StockEntity> warehouses)
    {
        var warehouseGroups = warehouses.
            GroupBy(stock => stock.Warehouse)
            .Select(warehouseGroup => ToModel(warehouseGroup, new WarehouseLocation(warehouseGroup.Key)))
            .ToList();

        return warehouseGroups;
    }

    private LegoSetModel ToModel(LegoSetEntity entity)
    {
        var legoSet = new LegoSetModel(
            sku: new Sku(entity.SKU),
            name: entity.Name,
            theme: entity.Theme,
            weight: entity.Weight,
            rating: entity.Rating,
            pieces: entity.PieceCount,
            uom: new Uom(entity.Uom),
            releaseYear: entity.ReleaseYear.ToString(),
            state: StateType.From(entity.State)
        );

        return legoSet;
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
            inventory: inventory
        );

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