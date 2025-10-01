using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.Warehouses;
using SupplyChain.Management.Application.UseCases.ClearanceSale;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Clearances;

[ApiController]
public class GetWarehouseClearanceEndpoint : ControllerBase
{
    private readonly IGetWarehouseClearanceUseCase _getWarehouseClearanceUseCase;

    public GetWarehouseClearanceEndpoint(IGetWarehouseClearanceUseCase getWarehouseClearanceUseCase)
    {
        _getWarehouseClearanceUseCase = getWarehouseClearanceUseCase;
    }

    [HttpGet("v1/warehouses/{location}/clearance")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseClearanceResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Query warehouse inventory for clearance sale candidates",
        OperationId = nameof(GetWarehouseClearance),
        Tags = [Constants.ApiTags.Clearance, Constants.ApiTags.Warehouse])]

    public ActionResult<IEnumerable<WarehouseClearanceResponse>> GetWarehouseClearance([FromRoute] string location, [FromQuery] WarehouseInventoryRequest request)
    {
        var clearanceLegoSets = _getWarehouseClearanceUseCase.GetWarehouseClearance(
            new WarehouseLocation(location),
            request.MaxQuantity,
            request.MinWeight,
            request.MaxWeight
            );

        return Ok(clearanceLegoSets.Select(clearanceLegoSet => new WarehouseClearanceResponse(clearanceLegoSet)));
    }
}