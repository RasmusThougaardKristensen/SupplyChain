using SupplyChain.Management.Domain.ClearanceSale;

namespace SupplyChain.Management.Api.Endpoints.Clearances;

public sealed record WarehouseClearanceResponse
{
    public string Sku { get; }
    public string Name { get; }
    public int Quantity { get; }
    public int Weight { get; }
    public int Placement { get; }
    public int Shelf { get; }

    public WarehouseClearanceResponse(WarehouseClearanceLegoSet warehouseClearanceLegoSet)
    {
        Sku = warehouseClearanceLegoSet.Sku.Id;
        Name = warehouseClearanceLegoSet.Name;
        Quantity = warehouseClearanceLegoSet.Quantity;
        Weight = warehouseClearanceLegoSet.Weight;
        Placement = warehouseClearanceLegoSet.Placement.Placement;
        Shelf = warehouseClearanceLegoSet.Placement.Shelf;
    }
}