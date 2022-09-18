using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace sample
{
    public class Person : Entity<int>, IMultiTenant
    {

        public string Name { get; set; }
        public Guid? TenantId { get; set; }
    }
}
