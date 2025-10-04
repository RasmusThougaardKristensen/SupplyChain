using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Management.Application.Services.Warehouses;
using SupplyChain.Management.Application.UseCases.LegoSets;
using SupplyChain.Management.Application.UseCases.Orders;
using SupplyChain.Management.Application.UseCases.Shipments;
using SupplyChain.Management.Application.UseCases.Warehouses;
using SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;
using SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

namespace SupplyChain.Management.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IGetLegoSetUseCase, GetLegoSetUseCase>();
        services.AddScoped<IGetWarehouseUseCase, GetWarehouseUseCase>();
        services.AddScoped<IGetOrderUseCase, GetOrderUseCase>();
        services.AddScoped<IRegisterShipmentToWarehouseUseCase, RegisterShipmentToWarehouseUseCase>();
        services.AddScoped<IRegisterShipmentToCustomerUseCase, RegisterShipmentToCustomerUseCase>();
        services.AddScoped<IGetWarehouseClearanceUseCase, GetWarehouseClearanceUseCase>();
        services.AddScoped<IWarehouseClearanceDtoMapper, WarehouseClearanceDtoMapper>();
        services.AddScoped<IGetWarehouseSummaryUseCase, GetWarehouseSummaryUseCase>();
        services.AddScoped<IWarehouseSummaryService, WarehouseSummaryService>();

        return services;
    }
}