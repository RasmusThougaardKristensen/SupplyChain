using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Domain.Orders;

public class OrderModel
{
    public OrderId Id { get; }

    public IReadOnlyList<LegoSetModel> LegoSets => _legoSets;
    private List<LegoSetModel> _legoSets;

    public int OrderWeight => CalculateOrderWeight();

    public OrderModel(List<LegoSetModel> legoSets)
        : this(
            id: new OrderId(),
            legoSets: legoSets){ }

    public OrderModel(OrderId id, List<LegoSetModel> legoSets)
    {
        Id = id;
        _legoSets = legoSets;
    }

    private int CalculateOrderWeight()
    {
        return _legoSets.Sum(legoSet => legoSet.Weight);
    }
}