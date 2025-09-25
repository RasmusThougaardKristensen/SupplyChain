namespace SupplyChain.Management.Domain.Common;

public abstract record GuidId
{
    public Guid Uid { get; }

    protected GuidId(Guid uid)
    {
        if (uid == Guid.Empty)
        {
            throw new ArgumentException("Guid must not be empty", nameof(uid));
        }

        Uid = uid;
    }

    protected GuidId() : this(Guid.NewGuid()) { }
}