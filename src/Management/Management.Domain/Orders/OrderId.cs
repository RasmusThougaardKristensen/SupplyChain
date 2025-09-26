using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.Orders;

public record OrderId : GuidId
{
    public OrderId() {}
    public OrderId(Guid id) : base(id) { }
}