using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.ClearanceSale;
using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.ClearanceSale;

public class GetWarehouseGetWarehouseClearanceUseCase : IGetWarehouseClearanceUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ILegoSetRepository _legoSetRepository;
    private readonly IWarehouseClearanceResultMapper _warehouseClearanceResultMapper;

    public GetWarehouseGetWarehouseClearanceUseCase(IWarehouseRepository warehouseRepository, ILegoSetRepository legoSetRepository, IWarehouseClearanceResultMapper warehouseClearanceResultMapper)
    {
        _warehouseRepository = warehouseRepository;
        _legoSetRepository = legoSetRepository;
        _warehouseClearanceResultMapper = warehouseClearanceResultMapper;
    }

    public IReadOnlyList<WarehouseClearanceLegoSet> GetWarehouseClearance(WarehouseLocation location, int maxQuantity, int minWeight, int maxWeight)
    {
        var warehouse = _warehouseRepository.GetWarehouseByLocation(location);
        if (warehouse is null)
        {
            return new List<WarehouseClearanceLegoSet>();
        }

        var lowStockItems = warehouse.Inventory.Stocks
            .Where(stock => stock.Quantity <= maxQuantity && stock.IsAvailable)
            .ToList();

        var lowStockSkus = lowStockItems.Select(stock => stock.Sku).ToList();
        var legoSets = _legoSetRepository.GetLegoSetsByWeight(
            lowStockSkus,
            minWeight,
            maxWeight);

        return _warehouseClearanceResultMapper.ToClearanceItems(lowStockItems, legoSets)
            .OrderByDescendingWeight();
    }
}