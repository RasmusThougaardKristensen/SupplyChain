using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

public sealed record WarehouseSummaryDto
{
    public WarehouseLocation Location { get; }

    public IReadOnlyList<CategoryStockDto> CategoryStocks => _categoryStocks;
    private readonly IReadOnlyList<CategoryStockDto> _categoryStocks;

    public WarehouseSummaryDto(WarehouseLocation location, IReadOnlyList<CategoryStockDto> categoryStocks)
    {
        Location = location;
        _categoryStocks = categoryStocks;
    }
}