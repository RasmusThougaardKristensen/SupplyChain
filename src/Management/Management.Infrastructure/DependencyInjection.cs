using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Infrastructure.Datasets;

namespace SupplyChain.Management.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services.AddScoped<ICsvComponent, CsvComponent>();
        return services;
    }
}