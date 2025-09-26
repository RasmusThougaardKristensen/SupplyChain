namespace SupplyChain.Management.Domain.LegoSets;

public sealed record StateType
{
    public static readonly StateType Active = new("ACTIVE");
    public static readonly StateType Retired = new("RETIRED");
    public static readonly StateType Unreleased = new("UNRELEASED");

    public static StateType From(string state)
    {

        return state.ToUpper() switch
        {
            "ACTIVE" => Active,
            "RETIRED" => Retired,
            "UNRELEASED" => Unreleased,
            _ => throw new ArgumentException($"Unexpected state: {state}")
        };
    }

    private readonly string _state;

    private StateType(string state)
    {
        _state = state;
    }

    public override string ToString()
    {
        return _state;
    }
}