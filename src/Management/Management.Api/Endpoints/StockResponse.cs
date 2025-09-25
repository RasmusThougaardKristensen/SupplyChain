using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Api.Endpoints;

public record StockResponse
{
    public string Sku { get; }
    public int Quantity { get; }
    public DateTime DeliveryDate { get; }
    public string Uom { get; }
    public int Placement { get; }
    public int Shelf { get; }

    public StockResponse(Stock stock)
    {
        Sku = stock.Sku.Id;
        Quantity = stock.Quantity;
        DeliveryDate = stock.DeliveryDate;
        Uom = stock.Uom.Id;
        Placement = stock.Placement.Placement;
        Shelf = stock.Placement.Shelf;
    }
}