using SupplyChain.Management.Domain.Warehouse;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

public record InventoryResponse
{
    public List<StockResponse> Stocks { get; }

    public InventoryResponse(Inventory inventory)
    {
        Stocks = inventory.Stocks.Select(stock => new StockResponse(stock)).ToList();
    }
}