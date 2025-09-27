using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Domain.Warehouses;

public sealed record Inventory
{
    public IReadOnlyList<Stock> Stocks => _stocks;
    private readonly List<Stock> _stocks;

    public Inventory(List<Stock> stocks)
    {
        _stocks = stocks;
    }

    public void IncreaseStockLevel(Stock increaseStock)
    {
        var existingStock = _stocks.FirstOrDefault(stock => stock.Sku.Id == increaseStock.Sku.Id);

        if (existingStock == null)
        {
            throw new InvalidOperationException($"Stock with SKU '{increaseStock.Sku.Id}' not found in warehouse inventory");
        }

        existingStock.IncreaseQuantity(increaseStock.Quantity);
    }

    public void DecreaseStockLevel(Stock decreaseStock)
    {
        var existingStock = _stocks.FirstOrDefault(stock => stock.Sku.Id == decreaseStock.Sku.Id);

        if (existingStock == null)
        {
            throw new InvalidOperationException($"Stock with SKU '{decreaseStock.Sku.Id}' not found in warehouse inventory");
        }

        existingStock.DecreaseQuantity(decreaseStock.Quantity);
    }
}