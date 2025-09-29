namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public sealed class StockEntity
{
    public string Warehouse { get; set; }
    public string SKU { get; set; }
    public int Quantity { get; set; }
    public string DeliveryDate { get; set; }
    public string Uom { get; set; }
    public int Placement { get; set; }
    public int Shelf { get; set; }
}