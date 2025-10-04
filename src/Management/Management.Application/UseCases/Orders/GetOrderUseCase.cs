using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Orders;

namespace SupplyChain.Management.Application.UseCases.Orders;

public class GetOrderUseCase : IGetOrderUseCase
{
    public GetOrderUseCase() { }

    public OrderModel GetOrderById(OrderId orderId)
    {
        var order = CreateOrderExample(orderId);

        return order;
    }

    private OrderModel CreateOrderExample(OrderId orderId)
    {
        var legoSetOne = new LegoSetModel(new Sku("90794424"), "The Deep End: The Shadowy Shoal", "Benthic Horror", 3000, "9", 789, new Uom("BOX"), "2025", StateType.Retired);
        var legoSetTwo = new LegoSetModel(new Sku("91468175"), "Njord's Voyage: The Sea God's Journey", "Ancient Pantheons", 4500, "6", 789, new Uom("BOX"), "2023", StateType.Active);

        var legoSets = new List<LegoSetModel>
        {
            legoSetOne,
            legoSetTwo
        };

        var order = new OrderModel(orderId, legoSets);

        return order;
    }
}