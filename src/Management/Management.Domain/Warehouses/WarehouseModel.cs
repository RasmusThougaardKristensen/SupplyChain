using SupplyChain.Management.Domain.Warehouse;

namespace SupplyChain.Management.Domain.Warehouses;

public class WarehouseModel
{
    public WarehouseId WarehouseId { get; }
    public string Location { get; }
    public Inventory Inventory { get; }

    public WarehouseModel(string location, Inventory inventory)
        : this(
            warehouseId:new WarehouseId(),
            location: location,
            inventory: inventory) { }

    public WarehouseModel(WarehouseId warehouseId, string location, Inventory inventory)
    {
        WarehouseId = warehouseId;
        Location = location;
        Inventory = inventory;
    }
}