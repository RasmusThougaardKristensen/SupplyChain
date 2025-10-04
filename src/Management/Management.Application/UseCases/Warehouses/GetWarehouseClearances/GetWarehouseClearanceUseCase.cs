using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public class GetWarehouseClearanceUseCase : IGetWarehouseClearanceUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ILegoSetRepository _legoSetRepository;
    private readonly IWarehouseClearanceDtoMapper _warehouseClearanceDtoMapper;

    public GetWarehouseClearanceUseCase(IWarehouseRepository warehouseRepository, ILegoSetRepository legoSetRepository, IWarehouseClearanceDtoMapper warehouseClearanceDtoMapper)
    {
        _warehouseRepository = warehouseRepository;
        _legoSetRepository = legoSetRepository;
        _warehouseClearanceDtoMapper = warehouseClearanceDtoMapper;
    }

    public IReadOnlyList<WarehouseClearanceLegoSetDto> GetWarehouseClearance(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight)
    {
        var warehouse = _warehouseRepository.GetWarehouseByLocation(location);
        if (warehouse is null)
        {
            return new List<WarehouseClearanceLegoSetDto>();
        }

        var lowStockItems = warehouse.Inventory.Stocks
            .Where(stock => stock.Quantity <= maxQuantity && stock.IsAvailable)
            .ToList();

        var lowStockSkus = lowStockItems.Select(stock => stock.Sku).ToList();
        var legoSets = _legoSetRepository.GetLegoSetsByWeight(
            lowStockSkus,
            minWeight,
            maxWeight);

        return _warehouseClearanceDtoMapper.ToClearanceItems(lowStockItems, legoSets)
            .OrderByDescendingWeight();
    }
}