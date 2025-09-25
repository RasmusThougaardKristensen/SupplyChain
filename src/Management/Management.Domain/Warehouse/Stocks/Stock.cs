using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Domain.Warehouse.Stocks;

public sealed record Stock
{
    public Sku Sku { get; }
    public int Quantity { get; }
    public DateTime DeliveryDate { get; } //TODO: Figure out if stock model should include delivery date of the stock?
    public Uom Uom { get; }
    public StockPlacement Placement { get; }

}