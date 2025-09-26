using SupplyChain.Management.Api.Endpoints.LegoSets;
using SupplyChain.Management.Domain.Orders;

namespace SupplyChain.Management.Api.Endpoints.Orders;

public sealed record OrderResponse
{
    public Guid OrderId { get; }
    public int OrderWeight { get; }
    public IEnumerable<LegoSetResponse> LegoSets { get; }

    public OrderResponse(OrderModel order)
    {
        OrderId = order.Id.Uid;
        OrderWeight = order.OrderWeight;
        LegoSets = order.LegoSets.Select(legoSet => new LegoSetResponse(legoSet));
    }
}