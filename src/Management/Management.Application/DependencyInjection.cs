using Microsoft.Extensions.DependencyInjection;

namespace SupplyChain.Management.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services;
    }
}