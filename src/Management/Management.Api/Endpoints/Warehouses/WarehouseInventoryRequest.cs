using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;


public sealed record WarehouseInventoryRequest : IValidatableObject
{
    [SwaggerSchema("Maximum quantity threshold - returns items with this quantity or fewer")]
    public int MaxQuantity { get; init; }
    [SwaggerSchema("Minimum weight threshold - returns lego sets heavier than this value")]
    public int MinWeight { get; init; }
    [SwaggerSchema("Maximum weight threshold - returns lego sets lighter than this value")]
    public int MaxWeight { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MaxQuantity < 0)
        {
            yield return new ValidationResult($"Max quantity must be greater than 0");
        }

        if (MinWeight < 0)
        {
            yield return new ValidationResult($"Min weight must be greater than 0");
        }

        if (MaxWeight < 0)
        {
            yield return new ValidationResult($"Max weight must be greater than 0");
        }
    }
}