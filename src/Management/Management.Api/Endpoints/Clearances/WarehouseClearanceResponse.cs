using SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

namespace SupplyChain.Management.Api.Endpoints.Clearances;

public sealed record WarehouseClearanceResponse
{
    public string Sku { get; }
    public string Name { get; }
    public int Quantity { get; }
    public int Weight { get; }
    public int Placement { get; }
    public int Shelf { get; }

    public WarehouseClearanceResponse(WarehouseClearanceLegoSetDto warehouseClearanceLegoSetDto)
    {
        Sku = warehouseClearanceLegoSetDto.Sku.Id;
        Name = warehouseClearanceLegoSetDto.Name;
        Quantity = warehouseClearanceLegoSetDto.Quantity;
        Weight = warehouseClearanceLegoSetDto.Weight;
        Placement = warehouseClearanceLegoSetDto.Placement.Placement;
        Shelf = warehouseClearanceLegoSetDto.Placement.Shelf;
    }
}