using System.Globalization;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public class WarehousesRepository : IWarehouseRepository
{
    private readonly ManagementDbContext _dbContext;

    public WarehousesRepository(ManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<WarehouseModel>> GetWarehousesWithSkus(IReadOnlyList<Sku> requestedSkus)
    {
        var legoSetSkus = requestedSkus.Select(sku => sku.Id).ToHashSet();
        var availableStocks = await _dbContext.Stock
            .Where(stock => legoSetSkus.Contains(stock.SKU))
            .GroupBy(stock => stock.Warehouse)
            .ToListAsync();

        var warehouses = availableStocks
            .Select(stockInWarehouse =>
                ToModel(stockInWarehouse, new WarehouseLocation(stockInWarehouse.Key)))
            .ToList();

        return warehouses;
    }

    public async Task<WarehouseModel?> GetWarehouseByLocation(WarehouseLocation location)
    {
        var warehouse = await _dbContext.Stock.Where(stock => stock.Warehouse == location.Id)
            .ToListAsync();

        return ToModel(warehouse, location);
    }

    private static WarehouseModel ToModel(IEnumerable<StockEntity> stockEntities, WarehouseLocation warehouseLocation)
    {
        var stocks = new List<Stock>();
        foreach (var stockEntity in stockEntities)
        {
            var stock = new Stock(
                new Sku(stockEntity.SKU),
                stockEntity.Quantity,
                stockEntity.DeliveryDate,
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
}