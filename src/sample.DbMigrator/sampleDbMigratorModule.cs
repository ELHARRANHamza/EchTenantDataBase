using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using sample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace sample.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(sampleEntityFrameworkCoreModule),
    typeof(sampleApplicationContractsModule)
    )]
public class sampleDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        //context.Services.Replace(ServiceDescriptor.Transient<DefaultConnectionStringResolver, MultiTenantConnectionStringResolver>());
    }
}
