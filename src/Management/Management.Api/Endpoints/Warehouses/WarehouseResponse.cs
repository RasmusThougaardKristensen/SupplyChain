using SupplyChain.Management.Domain.Warehouses;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

public record WarehouseResponse
{
    public Guid Id { get; }
    public string Location { get; }
    public InventoryResponse Inventory { get; }

    public WarehouseResponse(WarehouseModel warehouse)
    {
        Id = warehouse.WarehouseId.Uid;
        Location = warehouse.Location.Id;
        Inventory = new InventoryResponse(warehouse.Inventory);
    }
}