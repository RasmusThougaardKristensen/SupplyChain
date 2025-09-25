using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.Warehouses;

public sealed record WarehouseId : GuidId
{
    public WarehouseId() {}
    public WarehouseId(Guid id) : base(id) { }
}