using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using sample.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace sample.EntityFrameworkCore;

public class EntityFrameworkCoresampleDbSchemaMigrator
    : IsampleDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICurrentTenant _currentTenant;

    public EntityFrameworkCoresampleDbSchemaMigrator(
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant)
    {
        _serviceProvider = serviceProvider;
        _currentTenant = currentTenant;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the sampleDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<sampleDbContext>()
            .Database
            .MigrateAsync();
        if (_currentTenant.Id != null)
        {
            var find = FindTenantConfiguration(_currentTenant.Id.GetValueOrDefault());
            var conection = find.ConnectionStrings.Values.FirstOrDefault();
            if (!string.IsNullOrEmpty(conection))
            {
                await _serviceProvider
                    .GetRequiredService<DemoDbContext>()
                    .Database
                    .MigrateAsync();
            }
        }
    }

    protected TenantConfiguration FindTenantConfiguration(Guid tenantId)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        return serviceScope.ServiceProvider.GetRequiredService<ITenantStore>().Find(tenantId);
    }
}
