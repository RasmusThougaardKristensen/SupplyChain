using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Infrastructure.Repositories;
using SupplyChain.Management.Infrastructure.Repositories.LegoSets;
using SupplyChain.Management.Infrastructure.Repositories.Warehouses;

namespace SupplyChain.Management.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("postgresdb");
        services.AddDbContext<ManagementDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IWarehouseRepository, WarehousesRepository>();
        services.AddScoped<ILegoSetRepository, LegoSetRepository>();
        return services;
    }

    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
        return services;
    }
}