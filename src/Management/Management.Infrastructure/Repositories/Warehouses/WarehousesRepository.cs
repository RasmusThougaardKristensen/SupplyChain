using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public class WarehousesRepository : IWarehouseRepository
{
    private const string stocksPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Repositories/Warehouses/stock.csv";

    public IReadOnlyList<WarehouseModel> GetWarehousesWithSkus(IReadOnlyList<Sku> requestedSkus)
    {
        var stockEntities = ReadStocksFromCsv();

        var availableStocks = stockEntities
            .Where(stock => requestedSkus.Contains(new Sku(stock.SKU)))
            .GroupBy(stock => stock.Warehouse)
            .ToList();

        var warehouses = availableStocks
            .Select(stockInWarehouse =>
                ToModel(stockInWarehouse, new WarehouseLocation(stockInWarehouse.Key)))
            .ToList();

        return warehouses;
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
    private static IReadOnlyList<StockEntity> ReadStocksFromCsv()
    {
        using var reader = new StringReader(File.ReadAllText(stocksPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<StockCsvMap>();
        var stockEntities = csv.GetRecords<StockEntity>();

        return stockEntities.ToList();
    }
}