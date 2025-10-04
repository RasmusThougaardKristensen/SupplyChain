using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

public sealed record CategoryStockDto
{
    public Sku Sku { get; }
    public string Name { get; }
    public string Theme { get; }
    public int Quantity { get; }
    public CategoryStockDto(Sku sku, string name, string theme, int quantity)
    {
        Sku = sku;
        Name = name;
        Theme = theme;
        Quantity = quantity;
    }
}