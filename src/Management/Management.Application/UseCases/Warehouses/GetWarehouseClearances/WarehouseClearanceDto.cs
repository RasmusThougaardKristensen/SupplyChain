namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public sealed class WarehouseClearanceDto
{
    public IReadOnlyList<WarehouseClearanceLegoSetDto> Items => _items;
    private readonly IReadOnlyList<WarehouseClearanceLegoSetDto> _items;

    public WarehouseClearanceDto(IReadOnlyList<WarehouseClearanceLegoSetDto> items)
    {
        _items = items;
    }

    public IReadOnlyList<WarehouseClearanceLegoSetDto> OrderByDescendingWeight()
    {
        return _items.OrderByDescending(item => item.Weight)
            .ToList();
    }
}