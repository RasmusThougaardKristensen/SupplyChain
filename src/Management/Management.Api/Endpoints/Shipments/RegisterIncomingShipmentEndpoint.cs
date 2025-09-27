using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.Warehouses;
using SupplyChain.Management.Application.UseCases.Shipments;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Shipments;

[ApiController]
public class RegisterIncomingShipmentEndpoint : ControllerBase
{
    private readonly IRegisterShipmentToWarehouseUseCase _registerShipmentToWarehouseUseCase;

    public RegisterIncomingShipmentEndpoint(IRegisterShipmentToWarehouseUseCase registerShipmentToWarehouseUseCase)
    {
        _registerShipmentToWarehouseUseCase = registerShipmentToWarehouseUseCase;
    }

    [HttpPost("v1/warehouses/{location}/shipments")]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary = "Register incoming shipment to increase warehouse stock level",
        OperationId = nameof(RegisterShipmentToWarehouse),
        Tags = [Constants.ApiTags.Shipment])]
    public ActionResult RegisterShipmentToWarehouse([FromRoute] string location, [FromBody] RegisterShipmentRequest request)
    {
        var warehouse = _registerShipmentToWarehouseUseCase.RegisterIncomingShipmentToWarehouse(
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