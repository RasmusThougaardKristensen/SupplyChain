using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Management.Application.UseCases;

namespace SupplyChain.Management.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IGetSetUseCase, GetSetUseCase>();
        return services;
    }
}