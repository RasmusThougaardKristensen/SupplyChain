using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Domain.Warehouses.Stocks;

public sealed record Stock
{
    public Sku Sku { get; }
    public int Quantity { get; private set; }
    public DateTime DeliveryDate { get; } //TODO: Figure out if stock model should include delivery date of the stock?
    public Uom Uom { get; }
    public StockPlacement Placement { get; }

    public Stock(Sku sku, int quantity)
    {
        Sku = sku;
        Quantity = quantity;
    }

    public Stock(Sku sku, int quantity, DateTime deliveryDate, Uom uom, StockPlacement placement)
    {
        Sku = sku;
        Quantity = quantity;
        DeliveryDate = deliveryDate;
        Uom = uom;
        Placement = placement;
    }

    public void IncreaseQuantity(int increaseQuantity) => Quantity += increaseQuantity;
    public void DecreaseQuantity(int decreaseQuantity)
    {
        if (Quantity < decreaseQuantity)
        {
            throw new InvalidOperationException($"Insufficient stock for SKU {Sku.Id}. Available stock: {Quantity}");
        }

        Quantity -= decreaseQuantity;
    }
}