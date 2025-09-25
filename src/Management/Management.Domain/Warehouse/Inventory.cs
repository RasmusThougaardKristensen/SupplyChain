using SupplyChain.Management.Domain.Warehouse.Stocks;

namespace SupplyChain.Management.Domain.Warehouse;

public sealed record Inventory
{
    public IReadOnlyList<Stock> Stocks => _stocks;
    private readonly List<Stock> _stocks;

    public Inventory(List<Stock> stocks)
    {
        _stocks = stocks;
    }
}