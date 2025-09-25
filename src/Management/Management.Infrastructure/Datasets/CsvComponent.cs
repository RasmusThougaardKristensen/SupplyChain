using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Warehouse;
using SupplyChain.Management.Domain.Warehouse.Stocks;

namespace SupplyChain.Management.Infrastructure.Datasets;

public sealed class CsvComponent : ICsvComponent
{
    private const string setsPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Datasets/sets.csv";
    public LegoSetModel? GetSetBySku(Sku sku)
    {
        using var reader = new StringReader(File.ReadAllText(setsPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<LegoSetCsvMap>();
        var setEntities = csv.GetRecords<LegoSetEntity>();

        var entity = setEntities.FirstOrDefault(setEntity => setEntity.SKU == sku.Id);

        return entity is null ? null : ToModel(entity);
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
            state: entity.State
        );

        return legoSet;
    }

    public IReadOnlyList<LegoSetModel> ReadLegoSets(string path)
    {
        var legoSets = new List<LegoSetModel>();

        using var reader = new StringReader(File.ReadAllText(path));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Context.RegisterClassMap<LegoSetCsvMap>();
        var records = csv.GetRecords<LegoSetEntity>();

        foreach (var record in records)
        {
            try
            {
                legoSets.Add(ToModel(record));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing LegoSet record SKU {record.SKU}: {ex.Message}");
            }
        }

        return legoSets;
    }

    public IReadOnlyList<WarehouseModel> ReadWarehouses(string stockFilePath)
    {
        var stockRecords = ReadStockRecords(stockFilePath);
        var warehouses = new List<WarehouseModel>();

        // Group stocks by warehouse
        var wareHouses = stockRecords.GroupBy(s => s.Warehouse);

        foreach (var warehouseGroup in wareHouses)
        {
            var stocks = new List<Stock>();

            foreach (var stockRecord in warehouseGroup)
            {
                try
                {
                    var stock = new Stock(
                        new Sku(stockRecord.SKU),
                        stockRecord.Quantity,
                        ParseDeliveryDate(stockRecord.DeliveryDate),
                        new Uom(stockRecord.Uom),
                        new StockPlacement(stockRecord.Placement, stockRecord.Shelf));

                    stocks.Add(stock);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing Stock record SKU {stockRecord.SKU} in warehouse {stockRecord.Warehouse}: {ex.Message}");
                }
            }

            var inventory = new Inventory(stocks);
            var warehouse = new WarehouseModel(
                location: warehouseGroup.Key, // Using warehouse name as location
                inventory: inventory
            );

            warehouses.Add(warehouse);
        }

        return warehouses;
    }

    private List<StockEntity> ReadStockRecords(string filePath)
    {
        var stockRecords = new List<StockEntity>();

        using var reader = new StringReader(File.ReadAllText(filePath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Context.RegisterClassMap<StockCsvMap>();
        stockRecords.AddRange(csv.GetRecords<StockEntity>());

        return stockRecords;
    }

    private DateTime ParseDeliveryDate(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return result;
        }

        // Try different date formats if needed
        string[] formats = { "yyyy-MM-dd", "MM/dd/yyyy", "dd/MM/yyyy" };
        foreach (var format in formats)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
        }

        throw new FormatException($"Unable to parse date: {dateString}");
    }

    private Uom ParseUom(string uomString)
    {
        // Implement based on your Uom class structure
        // This is a placeholder - adjust according to your Uom implementation
        return new Uom(uomString ?? "each");
    }
}