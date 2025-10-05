using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Application.Services.Warehouses;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

public class GetWarehouseSummaryUseCase : IGetWarehouseSummaryUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ILegoSetRepository _legoSetRepository;
    private readonly IWarehouseSummaryService _warehouseSummaryService;

    public GetWarehouseSummaryUseCase(IWarehouseRepository warehouseRepository, ILegoSetRepository legoSetRepository, IWarehouseSummaryService warehouseSummaryService)
    {
        _warehouseRepository = warehouseRepository;
        _legoSetRepository = legoSetRepository;
        _warehouseSummaryService = warehouseSummaryService;
    }

    public async Task<WarehouseSummaryDto?> GetWarehouseStockSummary(WarehouseLocation location)
    {
        var warehouse = await _warehouseRepository.GetWarehouseByLocation(location);

        if (warehouse is null)
        {
            return null;
        }
        var stockSkus = warehouse.Inventory.Stocks.Select(stock => stock.Sku).ToList();
        var legoSets = await _legoSetRepository.GetLegoSetBySkus(stockSkus);

        return _warehouseSummaryService.GetWarehouseStockSummary(location, warehouse.Inventory.Stocks, legoSets);
    }
}