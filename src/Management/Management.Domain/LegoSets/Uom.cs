using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.LegoSets;

public sealed record Uom : StringId
{
    public Uom(string id) : base(id) { }
}