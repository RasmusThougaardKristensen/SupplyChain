using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.LegoSets;
using SupplyChain.Management.Application.UseCases;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

[ApiController]
public class GetWarehouseInventoryEndpoint : ControllerBase
{
    private readonly IGetWarehouseUseCase _getWarehouseUseCase;

    public GetWarehouseInventoryEndpoint(IGetWarehouseUseCase getWarehouseUseCase)
    {
        _getWarehouseUseCase = getWarehouseUseCase;
    }

    [HttpGet("v1/warehouses/{location}/inventory")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Query warehouse inventory for clearance sale candidates",
        OperationId = nameof(GetWarehouseInventory),
        Tags = [Constants.ApiTags.Warehouse])]

    public ActionResult<LegoSetResponse> GetWarehouseInventory([FromRoute] string location, [FromQuery] WarehouseInventoryRequest request)
    {
        var warehouseInventory = _getWarehouseUseCase.GetWarehouseInventory(
            new WarehouseLocation(location),
            request.MaxQuantity,
            request.MinWeight,
            request.MaxWeight
            );

        if (warehouseInventory is null)
        {
            return NotFound();
        }
        return Ok(new WarehouseResponse(warehouseInventory));
    }
}