using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.LegoSet;

public sealed record Uom : StringId
{
    public Uom(string id) : base(id) { }
}