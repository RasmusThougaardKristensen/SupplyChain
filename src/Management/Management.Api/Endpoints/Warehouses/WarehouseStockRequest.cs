using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

public sealed record WarehouseStockRequest : IValidatableObject
{
    [SwaggerSchema("Stock Keeping Unit id of lego set")]
    public required string Sku { get; init; }

    [SwaggerSchema("State that will be linked to lego set. Allowed state values: 'Active', 'Retired' and 'Unreleased'")]
    public required string State { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validValues = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) {"Active", "Retired", "Unreleased"};
        if (!validValues.Contains(State))
        {
            yield return new ValidationResult($"Invalid State: '{State}'. Only 'Active', 'Retired' and 'Unreleased' are valid");
        }
    }
}