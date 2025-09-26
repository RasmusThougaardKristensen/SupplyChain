using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.LegoSets;
using SupplyChain.Management.Application.UseCases.Orders;
using SupplyChain.Management.Domain.Orders;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Orders;

[ApiController]
public class GetOrderByIdEndpoint : ControllerBase
{
    private readonly IGetOrderUseCase _getOrderUseCase;

    public GetOrderByIdEndpoint(IGetOrderUseCase getOrderUseCase)
    {
        _getOrderUseCase = getOrderUseCase;
    }

    [HttpGet("v1/orders/{id}")]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Get order for a given order id",
        OperationId = nameof(GetOrderById),
        Tags = [Constants.ApiTags.Order])]

    public ActionResult<LegoSetResponse> GetOrderById([FromRoute] Guid id)
    {
        var order = _getOrderUseCase.GetOrderById(new OrderId(id));

        if (order is null)
        {
            return NotFound();
        }

        var response = new OrderResponse(order);
        return Ok(response);
    }
}