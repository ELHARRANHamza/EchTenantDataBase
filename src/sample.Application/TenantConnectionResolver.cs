using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace sample
{
    public class TenantConnectionResolver: DefaultConnectionStringResolver
    {
        private readonly ICurrentTenant _currentTenant;

        private readonly IServiceProvider _serviceProvider;
        public TenantConnectionResolver(IOptionsMonitor<AbpDbConnectionOptions> options, ICurrentTenant currentTenant,IServiceProvider serviceProvider) :base(options)
        {
            _currentTenant = currentTenant;
            _serviceProvider = serviceProvider;
        }
        public override async Task<string> ResolveAsync(string connectionStringName = null)
        {
            if (_currentTenant.Id.HasValue && connectionStringName == "Default")
            {
                var find = FindTenantConfiguration(_currentTenant.Id.GetValueOrDefault());
                var conection = find.ConnectionStrings.Values.FirstOrDefault();
                return conection;
            }
            return await base.ResolveAsync(connectionStringName);
        }
        public override  string Resolve(string connectionStringName = null)
        {
            if (_currentTenant.Id.HasValue && connectionStringName == "Default")
            {
                var find = FindTenantConfiguration(_currentTenant.Id.GetValueOrDefault());
                var conection = find.ConnectionStrings.Values.FirstOrDefault();
                return conection;
            }
            return  base.Resolve(connectionStringName);
        }


        protected TenantConfiguration FindTenantConfiguration(Guid tenantId)
        {
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
           
            return serviceScope.ServiceProvider.GetRequiredService<ITenantStore>().Find(tenantId);
        }
    }
}

