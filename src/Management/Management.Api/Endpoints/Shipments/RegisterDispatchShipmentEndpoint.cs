using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.Warehouses;
using SupplyChain.Management.Application.UseCases.Shipments;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Shipments;

[ApiController]
public class RegisterDispatchShipmentEndpoint : ControllerBase
{
    private readonly IRegisterShipmentToCustomerUseCase _registerShipmentToCustomerUseCase;

    public RegisterDispatchShipmentEndpoint(IRegisterShipmentToCustomerUseCase registerShipmentToCustomerUseCase)
    {
        _registerShipmentToCustomerUseCase = registerShipmentToCustomerUseCase;
    }

    [HttpPost("v1/warehouses/{location}/dispatches")]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary = "Register dispatch shipment to decrease warehouse stock level",
        Description = "Records dispatch of goods from warehouse to customers",
        OperationId = nameof(RegisterDispatchShipmentToCustomer),
        Tags = [Constants.ApiTags.Shipment])]
    public ActionResult RegisterDispatchShipmentToCustomer([FromRoute] string location, [FromBody] RegisterShipmentRequest request)
    {
        var warehouse = _registerShipmentToCustomerUseCase.RegisterDispatchShipmentToCustomer(
            new WarehouseLocation(location),
            new Sku(request.Stock.Sku),
            request.Stock.Quantity);

        if (warehouse is null)
        {
            return NotFound();
        }

        return Ok(new WarehouseResponse(warehouse));
    }
}