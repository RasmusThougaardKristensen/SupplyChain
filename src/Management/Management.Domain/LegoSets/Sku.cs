using SupplyChain.Management.Domain.Common;

namespace SupplyChain.Management.Domain.LegoSets;

public sealed record Sku : StringId
{
    public Sku(string id) : base(id) { }
}