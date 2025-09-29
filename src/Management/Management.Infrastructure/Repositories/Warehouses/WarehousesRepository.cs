using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Repositories;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public class WarehousesRepository : IWarehouseRepository
{
    private const string stocksPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Repositories/Warehouses/stock.csv";

    private static IReadOnlyList<StockEntity> ReadStocksFromCsv()
    {
        using var reader = new StringReader(File.ReadAllText(stocksPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<StockCsvMap>();
        var stockEntities = csv.GetRecords<StockEntity>();

        return stockEntities.ToList();
    }
}