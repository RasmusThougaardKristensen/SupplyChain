using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Infrastructure.Datasets;
using SupplyChain.Management.Infrastructure.Repositories.LegoSets;
using SupplyChain.Management.Infrastructure.Repositories.Warehouses;

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
        services.AddScoped<IWarehouseRepository, WarehousesRepository>();
        services.AddScoped<ILegoSetRepository, LegoSetRepository>();
        return services;
    }
}