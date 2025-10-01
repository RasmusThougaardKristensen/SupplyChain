namespace SupplyChain.Management.Domain.ClearanceSale;

public sealed class WarehouseClearanceResult
{
    public IReadOnlyList<WarehouseClearanceLegoSet> Items => _items;
    private readonly IReadOnlyList<WarehouseClearanceLegoSet> _items;

    public WarehouseClearanceResult(IReadOnlyList<WarehouseClearanceLegoSet> items)
    {
        _items = items;
    }

    public IReadOnlyList<WarehouseClearanceLegoSet> OrderByDescendingWeight()
    {
        return _items.OrderByDescending(item => item.Weight)
            .ToList();
    }
}