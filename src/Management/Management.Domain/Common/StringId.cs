namespace SupplyChain.Management.Domain.Common;

public abstract record StringId
{
    public string Id { get; }

    protected StringId(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("String must not be empty", nameof(id));
        }

        Id = id;
    }
}