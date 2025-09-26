using SupplyChain.Management.Domain.Orders;

namespace SupplyChain.Management.Application.UseCases.Orders;

public interface IGetOrderUseCase
{
    OrderModel GetOrderById(OrderId orderId);
}