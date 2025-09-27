using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Shipments;

public sealed record RegisterShipmentRequest
{
    [SwaggerSchema("Stock information for the LEGO sets included in this shipment")]
    public required RegisterShipmentStockRequest Stock { get; init; }
}