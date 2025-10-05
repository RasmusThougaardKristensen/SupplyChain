using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupplyChain.Management.Infrastructure.Repositories;

namespace SupplyChain.Management.Infrastructure;

public static class Installer
{
    public static async Task MigrateDatabase(this IHost app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var db = scope.ServiceProvider.GetRequiredService<ManagementDbContext>();
        await db.Database.MigrateAsync();
    }
}