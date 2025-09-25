using Microsoft.Extensions.DependencyInjection;

namespace SupplyChain.Management.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}