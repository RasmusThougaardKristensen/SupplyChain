using SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;

namespace SupplyChain.Management.Api.Endpoints.Warehouses.GetStockSummary;

public sealed record WarehouseSummaryResponse
{
    public string Location { get; }

    public IReadOnlyList<CategoryStockResponse> CategoryStock { get; }

    public WarehouseSummaryResponse(WarehouseSummaryDto warehouseSummaryDto)
    {
        Location = warehouseSummaryDto.Location.Id;
        CategoryStock = warehouseSummaryDto.CategoryStocks
            .Select(categoryStock => new CategoryStockResponse(categoryStock))
            .ToList();
    }

    public sealed record CategoryStockResponse
    {
        public string Sku { get; }
        public string Name { get; }
        public string Theme { get; }
        public int Quantity { get; }

        public CategoryStockResponse(CategoryStockDto categoryStockDto)
        {
            Sku = categoryStockDto.Sku.Id;
            Name = categoryStockDto.Name;
            Theme = categoryStockDto.Theme;
            Quantity = categoryStockDto.Quantity;
        }
    }
}