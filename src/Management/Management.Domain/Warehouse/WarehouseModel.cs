namespace SupplyChain.Management.Domain.Warehouse;

public class WarehouseModel
{
    public WarehouseId WarehouseId { get; }
    public string Location { get; }
    public Inventory Inventory { get; }
    public WarehouseModel(WarehouseId warehouseId, string location, Inventory inventory)
    {
        WarehouseId = warehouseId;
        Location = location;
        Inventory = inventory;
    }
}