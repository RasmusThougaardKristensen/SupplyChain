using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.Warehouses.GetAvailableStock;
using SupplyChain.Management.Application.UseCases.Shipments;
using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Shipments;

[ApiController]
public class RegisterReceiptShipmentEndpoint : ControllerBase
{
    private readonly IRegisterShipmentToWarehouseUseCase _registerShipmentToWarehouseUseCase;

    public RegisterReceiptShipmentEndpoint(IRegisterShipmentToWarehouseUseCase registerShipmentToWarehouseUseCase)
    {
        _registerShipmentToWarehouseUseCase = registerShipmentToWarehouseUseCase;
    }

    [HttpPost("v1/warehouses/{location}/receipts")]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary = "Register receipt shipment to increase warehouse stock level",
        Description = "Records receipt of goods arriving at the warehouse from suppliers",
        OperationId = nameof(RegisterReceiptShipmentToWarehouse),
        Tags = [Constants.ApiTags.Shipment])]
    public async Task<ActionResult<WarehouseResponse>> RegisterReceiptShipmentToWarehouse([FromRoute] string location, [FromBody] RegisterShipmentRequest request)
    {
        var warehouse = await _registerShipmentToWarehouseUseCase.RegisterReceiptShipmentToWarehouse(
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