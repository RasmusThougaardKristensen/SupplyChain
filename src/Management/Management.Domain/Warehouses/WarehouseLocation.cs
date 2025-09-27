using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.Warehouses;

public record WarehouseLocation : StringId
{
    public WarehouseLocation(string id) : base(id) { }
}